const host = 'https://localhost:7297'

export async function fetchUsuario() {
        const response = await fetch(`${host}/users/info/${sessionStorage.getItem("usr")}`);
        const data = await response.json();
        if(response.status == 200) {
            return data;
        }
        if(response.status >200) {
            return {error:true}
        }
}

export async function crearUsuario(dataUser) {
    const body = JSON.stringify(dataUser) 
    
    const opt =   {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: body}
    
    const response = await fetch(`${host}/users/registrar`,opt)
    const data = await response.json();
    return data;
}


export async function autenticarUsuario(dataUser) {
    const body = JSON.stringify(dataUser) 
    
    const opt =   {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: body}
    
    const response = await fetch(`${host}/users/autenticar`,opt)
    if(response.status == 200) {
        const data =await response.json();
        console.log(data);
        sessionStorage.setItem("usr", data.user_id)
        return {success:true}
    }
    if(response.status >200 && response.status <500) {
        return {error:true}
    }

    
}

export async function fetchContactos() {
    const response = await fetch(`${host}/contacts/user/${sessionStorage.getItem("usr")}`);
    const data = await response.json();
    if(response.status == 200) {
        return data;
    }
    if(response.status >200) {
        return {error:true}
    }
}

export async function actualizarContacto(idContact, dataContact) {
    const body = JSON.stringify(dataContact) 
    
    const opt =   {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: body}
    
    const response = await fetch(`${host}/contacts/${idContact}`,opt)
    const data = await response.json();
    return data;
}

export async function crearContacto( dataContact) {
    const body = JSON.stringify(dataContact) 
    
    const opt =   {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: body}
    
    const response = await fetch(`${host}/contacts`,opt)
    const data = await response.json();
    return data;
}

export async function deleteContacto(id) {
    
    const opt =   {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }}
    
    const response = await fetch(`${host}/contacts/user/${sessionStorage.getItem("usr")}/${id}`,opt)
    const data = await response.json();
    return data;
}

