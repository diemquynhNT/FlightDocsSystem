﻿using AutoMapper;
using AutoMapper.Features;
using DocumentService.Data;
using DocumentService.Dto;
using DocumentService.Model;
using DocumentService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System.Globalization;
using System.IO.Compression;
using System.Net;

namespace DocumentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocument _context;
        private readonly IMapper _mapper;

        public DocumentsController(IDocument idocument,IMapper imapper) {
            _context = idocument;
            _mapper = imapper;
        }
        [HttpPost("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile(string IdUser, string idFlight,[FromForm]DocumentFileVM doc,IFormFile file)
        {
            if (file == null)
            {
                return BadRequest();
            }

            try
            {
                var documents = _mapper.Map<Documents>(doc);
                await _context.ImportDocument(IdUser,idFlight,file,documents);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}