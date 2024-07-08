import * as rq from './httpRq.js'

let resTable = [];
let objIdSelected = 0;

const elemErr = document.getElementById('error')
const windowsLoc = window.location.pathname
if (windowsLoc.endsWith('presentacion.html')) {
    window.addEventListener('load', async () => {
        const res = await rq.fetchUsuario()
        if (res.hasOwnProperty('error')) {
            elemErr.style.display = 'block'
        }
        document.getElementById("name").textContent = res.name;
        document.getElementById("username").textContent = res.username;
        document.getElementById("descripcion").textContent = res.descripcion;
    })

    document.getElementById("close-sess").addEventListener('click', () => {
        sessionStorage.removeItem("usr")
    })
}
else if (windowsLoc.endsWith('registro.html')) {
    document.getElementById("info-sender").addEventListener('click', async () => {
        const name = document.getElementById('name').value;
        const username = document.getElementById('username').value;
        const password = document.getElementById('password').value;
        const descripcion = document.getElementById('descripcion').value;
        const res = await rq.crearUsuario({
            name: name,
            username: username,
            password: password,
            descripcion: descripcion
        });

        if (res.hasOwnProperty('error')) {
            elemErr.style.display = 'block'
        } else {

            window.location.href = "/autenticar.html";
        }
    })
}
else if (windowsLoc.endsWith('autenticar.html')) {
    document.getElementById("info-auth-sender").addEventListener('click', async () => {
        const username = document.getElementById('username').value;
        const password = document.getElementById('password').value;

        const res = await rq.autenticarUsuario({ username: username, password: password });
        console.log(res);
        if (res.hasOwnProperty('error')) {
            elemErr.style.display = 'block'
        } else {

            window.location.href = "/presentacion.html";
        }
    })
}
else if (windowsLoc.endsWith("contactos.html")) {
    window.addEventListener('load', async () => {
     render()
    })
    document.getElementById("add-btn").addEventListener('click', async ()=> clearInfoForm())
    document.getElementById("send").addEventListener('click', async () => writeObj())

    document.getElementById("userReference").innerText = sessionStorage.getItem("usr")
    const classes = document.getElementsByClassName("btn-updaters");
    console.log(classes);
    for (let i = 0; i < classes.length; i++) {
        const element = classes[i];
        element.addEventListener('click', () => {
            console.log(111);
            const id = parseInt(element.id.split("-")[1])
            console.log(id)
        })
    }


    // classes.forEach(element => {
    //     element.addEventListener('click', ()=> {
    //         const form  =document.getElementById("upd-1");
    //         const id = parseInt(form.id.split("-")[1])
    //         console.log(id)
    //     })
    // });
}

function bringDatosToFormModal(id) {
    const inputs = document.querySelectorAll('input[name]');
    const obj = resTable.find((elem) => { return elem.id == id });
    console.log(obj);
    if (obj) {
        inputs.forEach(input => {
            const name = input.name;
            if (obj.hasOwnProperty(name)) {
                input.value = obj[name];
            }
        });
    }
}

async function render() {
    const res = await rq.fetchContactos()
    if (res.hasOwnProperty('error')) {
        elemErr.style.display = 'block'
    }
    console.log(res);

    resTable = res;
    const tBody = document.getElementById('tbody-contacts');
    tBody.innerHTML = ''
    for (let id = 0; id < res.length; id++) {
        const element = res[id];
        const row = document.createElement('tr');
        for (let key in element) {
            if (element.hasOwnProperty(key)) {
                const cell = document.createElement('td');
                cell.textContent = element[key];
                row.appendChild(cell);
            }
        }
        const cellBtn = document.createElement('td');

        const updateButton = document.createElement('button');
        updateButton.className = 'btn btn-success btn-updaters';
        updateButton.id = 'upd-' + element.id;
        updateButton.setAttribute('data-bs-toggle', 'modal');
        updateButton.setAttribute('data-bs-target', '#exampleModal');

        updateButton.textContent = 'Actualizar';

        updateButton.addEventListener('click', () => {
            const id = parseInt(updateButton.id.split("-")[1])
            objIdSelected = id
            bringDatosToFormModal(id)
        })
        cellBtn.appendChild(updateButton);

        const deleteButton = document.createElement('button');
        deleteButton.className = 'btn btn-danger btn-deleters';
        updateButton.id = 'elim-' + element.id;
        deleteButton.textContent = 'Eliminar';

        deleteButton.addEventListener('click', () => {
            const id = parseInt(updateButton.id.split("-")[1])
            deleteObj(id)
        })
        cellBtn.appendChild(deleteButton);

        row.appendChild(cellBtn)
        tBody.appendChild(row);
    }
}

async function writeObj() {
    if(objIdSelected != 0 ) {
        const inputs = document.querySelectorAll('input[name]');
        const obj = resTable.find((elem) => { return elem.id == objIdSelected });
        inputs.forEach(input => {
            const name = input.name;
            if (obj.hasOwnProperty(name)) {
                obj[name] = input.value;
            }
        });  
        obj["user_id"] = sessionStorage.getItem("usr")
        const res = await rq.actualizarContacto(objIdSelected, obj)
        console.log(res);
        objIdSelected = 0;
    } else {
        let obj = {}

        const inputs = document.querySelectorAll('input[name]');
        inputs.forEach(input => {
            const name = input.name;
            obj[name] = input.value;
        }); 
        obj["user_id"] = sessionStorage.getItem("usr")
        console.log(obj);
        const res = await rq.crearContacto(obj)
        console.log(res);
    }
    render() 

}
function clearInfoForm() {
        const inputs = document.querySelectorAll('input[name]');
        inputs.forEach(input => {
            input.value = ""
            objIdSelected = 0
        });
}

async function deleteObj(id) {
    await rq.deleteContacto(id)
    render()
}










