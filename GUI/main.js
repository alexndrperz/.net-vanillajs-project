const options = {
    method: 'POST',
    headers: {
    'Content-Type': 'application/json',
    },
    body: JSON.stringify({msg: "Hola"}),
    };


fetch("https://localhost:7297/users/registrar", options)
.then((response) => response.json())
.then((response) => {console.log(response)})
.catch((err) => {console.log(err)})  
