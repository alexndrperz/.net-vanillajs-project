import * as rq from './httpRq.js'

const elemErr = document.getElementById('error') 
const windowsLoc =window.location.pathname
if(windowsLoc.endsWith('presentacion.html')) {
    window.addEventListener('load', async () => {
        const res = await rq.fetchUsuario()
        if(res.hasOwnProperty('error')) {
            elemErr.style.display = 'block'
        }
        document.getElementById("name").textContent =  res.name;
        document.getElementById("username").textContent =  res.username;
        document.getElementById("descripcion").textContent =  res.descripcion;
    })

    document.getElementById("close-sess").addEventListener('click', ()=> {
        sessionStorage.removeItem("usr")
    })
}
else if(windowsLoc.endsWith('registro.html')) {
    document.getElementById("info-sender").addEventListener('click', async () => {
        const name = document.getElementById('name').value;
        const username = document.getElementById('username').value;
        const password = document.getElementById('password').value;
        const descripcion= document.getElementById('descripcion').value;          
        const res = await rq.crearUsuario({
            name:name,
            username:username,
            password:password,
            descripcion:descripcion
        });

        if(res.hasOwnProperty('error')) {
            elemErr.style.display = 'block'
        } else {

            window.location.href = "/autenticar.html";
        }
    })
}
else if(windowsLoc.endsWith('autenticar.html')) {
    document.getElementById("info-auth-sender").addEventListener('click', async () => {
        const username = document.getElementById('username').value;
        const password = document.getElementById('password').value;
        
         const res = await rq.autenticarUsuario({username:username, password:password});
         console.log(res);
         if(res.hasOwnProperty('error')) {
            elemErr.style.display = 'block'
        } else {

            window.location.href = "/presentacion.html";
        }
    })
}









