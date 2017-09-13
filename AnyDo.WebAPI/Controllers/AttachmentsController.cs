using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnyDo.Data.Repositories;
using AnyDo.WebAPI.Models;
using AnyDo.Data.Entities;
using AutoMapper;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.ComponentModel.DataAnnotations;
using Microsoft.Net.Http.Headers;

namespace AnyDo.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Attachments")]
    public class AttachmentsController : Controller
    {
        IAttachmentRepository attachmentRepository;
        ITaskRepository taskRepository;
        IHostingEnvironment appEnvironment;

        public AttachmentsController(IAttachmentRepository attachmentRepository,
            ITaskRepository taskRepository,
            IHostingEnvironment appEnvironment)
        {
            this.attachmentRepository = attachmentRepository;
            this.taskRepository = taskRepository;
            this.appEnvironment = appEnvironment;
        }

        [HttpGet]
        public List<AttachmentApiModel> Get([FromQuery, Required]AttachmentFilterOptions filter)
        {
            var dbAttachment = attachmentRepository.GetByTaskId(filter.TaskId).ToList();
            var apiAttachment = Mapper.Map<List<Attachment>, List<AttachmentApiModel>>(dbAttachment);
            return apiAttachment;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var attachment = attachmentRepository.GetById(id);
            string fileFullPath = GetFilePathFull(id, attachment.FileNameFull);

            var memory = new MemoryStream();
            using (var stream = new FileStream(fileFullPath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(fileFullPath), attachment.FileNameFull);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int taskId, IFormFile file)
        {
            Attachment attachment = null;
            if (file != null)
            {
                attachment = new Attachment
                {
                    FileNameFull = file.FileName,
                    FileSizeInBites = file.Length,
                    TaskId = taskId,
                    Created = DateTime.Now
                };
                attachmentRepository.Add(attachment);

                taskRepository.IncrimentAttachmentCountById(taskId);

                string fileFullPath = GetFilePathFull(attachment.Id, file.FileName);
                using (var fileStream = new FileStream(fileFullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                attachment = attachmentRepository.GetById(attachment.Id);
                var apiAttachment = Mapper.Map<Attachment, AttachmentApiModel>(attachment);

                return Ok(apiAttachment);
            }

            return BadRequest();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var attachment = attachmentRepository.GetById(id);

            taskRepository.DecrimentAttachmentCountById(attachment.TaskId);

            string fileFullPath = GetFilePathFull(id, attachment.FileNameFull);
            if (System.IO.File.Exists(fileFullPath))
                System.IO.File.Delete(fileFullPath);

            attachmentRepository.Delete(attachment);
        }



        private string GetFilePathFull(int fileId, string fileNameFull)
        {
            string path = "/Files/" + fileId + "." + Path.GetExtension(fileNameFull);
            return appEnvironment.WebRootPath + path;
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}