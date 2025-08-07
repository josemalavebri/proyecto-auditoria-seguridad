// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


function buscarAuditorias() {
    const lugares = document.getElementById('lugares').value.trim();
    const facultad = document.getElementById('facultad').value.trim();
    const departamento = document.getElementById('departamento').value.trim();

    // Si todos están vacíos, limpiar el contenedor y salir
    if (!lugares && !facultad && !departamento) {
        document.getElementById('contenedor-auditorias').innerHTML = '';
        return;
    }

    const params = {};
    if (lugares) params.lugares = lugares;
    if (facultad) params.facultad = facultad;
    if (departamento) params.departamento = departamento;

    cargarDatos('Auditorias', params);
}


async function cargarDatos(handler, params = {}) {
    const query = new URLSearchParams(params).toString();
    const url = `/Index?handler=${handler}${query ? '&' + query : ''}`;

    const res = await fetch(url);
    const datos = await res.json();

    document.getElementById(`contenedor-${handler.toLowerCase()}`).innerHTML = generarTablaConDetalle(datos);
}

function generarTabla(datos) {
    if (!datos.length) return '<p>No hay datos</p>';

    let html = "<table class='table table-striped table-bordered table-hover'>";
    html += "<thead><tr>";
    for (let key in datos[0]) {
        html += `<th scope="col">${key}</th>`;
    }
    html += "</tr></thead><tbody>";

    for (const fila of datos) {
        html += "<tr>";
        for (let key in fila) {
            html += `<td>${fila[key]}</td>`;
        }
        html += "</tr>";
    }

    html += "</tbody></table>";
    return html;
}


document.getElementById('lugares').addEventListener('input', async function () {
    const valor = this.value.trim();
    const sugerenciasDiv = document.getElementById('sugerencias');

    // Limpiar si no hay nada escrito
    if (valor === '') {
        sugerenciasDiv.innerHTML = '';
        return;
    }

    try {
        const res = await fetch(`/Index?handler=Sugerencias&termino=${encodeURIComponent(valor)}`);
        const datos = await res.json();

        // Mostrar resultados
        sugerenciasDiv.innerHTML = '';
        datos.forEach(item => {
            const opcion = document.createElement('button');
            opcion.classList.add('list-group-item', 'list-group-item-action');
            opcion.textContent = item;
            opcion.addEventListener('click', () => {
                document.getElementById('lugares').value = item;
                sugerenciasDiv.innerHTML = '';
            });
            sugerenciasDiv.appendChild(opcion);
        });
    } catch (error) {
        console.error('Error al buscar sugerencias', error);
    }
});


async function detallarEncuesta(id) {
    const url = `/Index?handler=DetalleEncuesta&id=${id}`;
    const res = await fetch(url);
    const detalle = await res.json();

    document.getElementById('contenedor-detalle').innerHTML = generarTablaDetalle(detalle);
}


function generarTablaConDetalle(datos) {
    if (!datos.length) return '<p>No hay datos</p>';

    let html = "<table class='table table-striped table-bordered table-hover'>";
    html += "<thead><tr>";

    for (let key in datos[0]) {
        html += `<th scope="col">${key}</th>`;
    }
    html += `<th scope="col">Detallar</th>`;
    html += "</tr></thead><tbody>";

    for (const fila of datos) {
        html += "<tr>";
        for (let key in fila) {
            html += `<td>${fila[key]}</td>`;
        }

        // Suponiendo que la clave primaria del objeto es "id"
        html += `<td><button class="btn btn-sm btn-info" onclick="detallarEncuesta(${fila.idAuditoria})">Detallar</button></td>`;
        html += "</tr>";
    }

    html += "</tbody></table>";
    return html;
}

//5:05
// Autocompletar para facultad y departamento
    async function autocompletar(inputId, sugerenciasId, handler) {
        const input = document.getElementById(inputId);
    const sugerenciasDiv = document.getElementById(sugerenciasId);

    input.addEventListener('input', async function () {
            const valor = this.value.trim();

    if (valor === '') {
        sugerenciasDiv.innerHTML = '';
    return;
            }

    try {
                const res = await fetch(`/Index?handler=${handler}&termino=${encodeURIComponent(valor)}`);
    const datos = await res.json();

    sugerenciasDiv.innerHTML = '';
                datos.forEach(item => {
                    const opcion = document.createElement('button');
    opcion.classList.add('list-group-item', 'list-group-item-action');
    opcion.textContent = item;
                    opcion.addEventListener('click', () => {
        input.value = item;
    sugerenciasDiv.innerHTML = '';
                    });
    sugerenciasDiv.appendChild(opcion);
                });
            } catch (error) {
        console.error(`Error al buscar sugerencias de ${handler}`, error);
            }
        });
    }

    autocompletar('facultad', 'sugerencias-facultad', 'SugerenciasFacultad');
    autocompletar('departamento', 'sugerencias-departamento', 'SugerenciasDepartamento');


function generarTablaDetalle(detalle) {
    if (!detalle) return '<p>No hay datos disponibles.</p>';

    return `
        <table class="table table-bordered table-striped">
            <tr><th>Id Respuesta</th><td>${detalle.idRespuesta}</td></tr>
            <tr><th>Pregunta</th><td>${detalle.pregunta}</td></tr>
            <tr><th>Items Asociados</th><td>${detalle.itemsAsociados}</td></tr>
            <tr><th>Marcado</th><td>${detalle.marcado ? 'Sí' : 'No'}</td></tr>
        </table>
    `;
}
