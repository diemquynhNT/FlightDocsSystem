﻿using DocumentService.Model;

namespace DocumentService.Services
{
    public interface ITypeDocument
    {
        public List<TypeDocument> GetAllType();
        public Task<TypeDocument> GetById(string id);
        public Task<TypeDocument> AddNewTypeDocument(TypeDocument typeDocument, string idUser);
        public Task<TypeDocument> UpdateTypeDocument(string idType,TypeDocument type);
        public Task<bool> DeleteType(string idType);
        public void AddPermisstonGroup(string idGroup,string per,string idType);
    }
}
