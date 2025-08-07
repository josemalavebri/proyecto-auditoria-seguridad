function agregarItem() {
    const contenedor = document.getElementById('contenedor-items');

    const grupo = document.createElement('div');
    grupo.className = 'input-group mb-2';

    const input = document.createElement('input');
    input.type = 'text';
    input.name = 'items[]';
    input.className = 'form-control';
    input.placeholder = 'Ingrese un ítem';
    input.required = true;

    const boton = document.createElement('button');
    boton.type = 'button';
    boton.className = 'btn btn-outline-danger';
    boton.innerText = '-';
    boton.onclick = function () {
        contenedor.removeChild(grupo);
    };

    grupo.appendChild(input);
    grupo.appendChild(boton);
    contenedor.appendChild(grupo);
}