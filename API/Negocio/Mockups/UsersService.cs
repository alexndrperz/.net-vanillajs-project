using AutoMapper;
using Datos.DbContexts;
using Datos.DTOs;
using Datos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Negocio.Contracts;

namespace Negocio.Mockups
{
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;   
        private readonly  BdContext _dbContext; 
        public UsersService(IMapper mapper, BdContext bdContext)
        {
            _dbContext = bdContext;
            _mapper = mapper;
        }
        public async Task<bool> actualizarUsuario(int user_id, UsuarioCreateDTO usuario)
        {
            Usuario? userEnt = await _dbContext.Usuarios.FirstOrDefaultAsync(us => us.Id == user_id);
            if (userEnt == null) return false;
            _mapper.Map(usuario, userEnt);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<MsgServerMD> autenticarUsuarioAsync(UsuarioAuthDTO userCred)
        {
            Usuario? user = await _dbContext.Usuarios.FirstOrDefaultAsync(us => us.Username == userCred.username);
            if (user == null) return MsgServerMD.errorMsg(401, "Usuario no existente");
            if (user.Password != userCred.password) return MsgServerMD.errorMsg(401, "Contraseña incorrecta");
            return MsgServerMD.resulMsg(200, new { user_id = user.Id });
        }

        public async Task<bool> crearUsuarioClienteAsync(UsuarioCreateDTO usuario)
        {
            Usuario ent = _mapper.Map<Usuario>(usuario);
            ent.Role = "Cliente";
            await _dbContext.Usuarios.AddAsync(ent);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario?> getUsuarioAsync(int id)
        {
            Usuario? usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(us => us.Id == id);
            return usuario;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            List<Usuario> usuarios =await _dbContext.Usuarios.ToListAsync();
            return usuarios;    
        }
    }
}
