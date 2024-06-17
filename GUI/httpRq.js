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
    
    const response = await fetch(`${host}/localhost:7297/users/registrar`,opt)
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
        sessionStorage.setItem("usr", data.user_id)
        return {success:true}
    }
    if(response.status >200 && response.status <500) {
        return {error:true}
    }
}
