public class RepositorioDatos
{
    private static readonly Lazy<RepositorioDatos> instancia = new(() => new RepositorioDatos());
    public static RepositorioDatos Instancia => instancia.Value;

    private RepositorioDatos()
    {
        /*
        // Relaciones para UbicacionInstitucional
        foreach (var ui in ListaUbicacionInstitucional)
        {
            ui.Ubicacion = ListaUbicacions.FirstOrDefault(u => u.IdUbicacion == ui.Ubicacion.IdUbicacion);
            ui.Facultad = ListaFacultads.FirstOrDefault(f => f.IdFacultad == ui.Facultad.IdFacultad);
            ui.Departamento = ListaDepartamentos.FirstOrDefault(d => d.IdDepartamento == ui.Departamento.IdDepartamento);
        }

        // Relaciones para Auditoria
        foreach (var aud in ListaAuditorias)
        {
            aud.Ubicacion = ListaUbicacionInstitucional.FirstOrDefault(ui => ui.IdUbicacionInstitucional == aud.Ubicacion.IdUbicacion)?.Ubicacion;
            aud.Encuestas = ListaEncuestas.Where(e => e.IdAuditoria == aud.IdAuditoria).ToList();
        }

        // Relaciones para Persona
        foreach (var p in ListaPersonas)
        {
            p.Rol = ListaRols.FirstOrDefault(r => r.IdRol == p.Rol.IdRol);
        }

        // Relacionar Items a Preguntas (n a n)
        foreach (var pregunta in ListaPreguntas)
        {
            Console.WriteLine($"Pregunta: {pregunta.Texto}");
            foreach (var item in pregunta.Items)
            {
                Console.WriteLine($"  - Item: {item.Descripcion}");
            }
        }



        // Relacionar Items en Seguimientos
        foreach (var seg in ListaSeguimientos)
        {
            seg.Item = ListaItems.FirstOrDefault(i => i.IdItem == seg.Item.IdItem);
        }
    }

    // Colecciones de objetos, inicializadas con IDs para enlazar después

    public List<Ubicacion> ListaUbicacions { get; } = new List<Ubicacion>
    {
        new Ubicacion { IdUbicacion = 1, Nombre = "Campus Central" },
        new Ubicacion { IdUbicacion = 2, Nombre = "Campus Norte" },
        new Ubicacion { IdUbicacion = 3, Nombre = "Campus Sur" },
        new Ubicacion { IdUbicacion = 4, Nombre = "Campus Este" },
    };

    public List<Facultad> ListaFacultads { get; } = new List<Facultad>
    {
        new Facultad { IdFacultad = 1, Nombre = "Ingeniería" },
        new Facultad { IdFacultad = 2, Nombre = "Ciencias Económicas" },
        new Facultad { IdFacultad = 3, Nombre = "Salud" },
        new Facultad { IdFacultad = 4, Nombre = "Artes" },
    };

    public List<Departamento> ListaDepartamentos { get; } = new List<Departamento>
    {
        new Departamento { IdDepartamento = 1, Nombre = "Sistemas" },
        new Departamento { IdDepartamento = 2, Nombre = "Contabilidad" },
        new Departamento { IdDepartamento = 3, Nombre = "Enfermería" },
        new Departamento { IdDepartamento = 4, Nombre = "Música" },
    };

    public List<Rol> ListaRols { get; } = new List<Rol>
    {
        new Rol { IdRol = 1, Nombre = "Administrador" },
        new Rol { IdRol = 2, Nombre = "Supervisor" },
        new Rol { IdRol = 3, Nombre = "Auditor" },
        new Rol { IdRol = 4, Nombre = "Usuario" },
    };

    public List<Persona> ListaPersonas { get; } = new List<Persona>
    {
        new Persona { IdPersona = 1, Nombre = "Ana Pérez", Correo = "ana.perez@ejemplo.com", Rol = new Rol { IdRol = 1 } },
        new Persona { IdPersona = 2, Nombre = "Luis Gómez", Correo = "luis.gomez@ejemplo.com", Rol = new Rol { IdRol = 2 } },
        new Persona { IdPersona = 3, Nombre = "Sofía Díaz", Correo = "sofia.diaz@ejemplo.com", Rol = new Rol { IdRol = 3 } },
        new Persona { IdPersona = 4, Nombre = "Carlos Ruiz", Correo = "carlos.ruiz@ejemplo.com", Rol = new Rol { IdRol = 4 } },
    };

    public List<Seccion> ListaSecciones { get; } = new List<Seccion>
    {
        new Seccion { IdSeccion = 1, Nombre = "Infraestructura" },
        new Seccion { IdSeccion = 2, Nombre = "Seguridad Informática" },
        new Seccion { IdSeccion = 3, Nombre = "Uso de Sistemas" },
        new Seccion { IdSeccion = 4, Nombre = "Concientización" },
    };

    public List<Item> ListaItems { get; } = new List<Item>
    {
        new Item { IdItem = 1, Descripcion = "Contraseñas con más de 8 caracteres" },
        new Item { IdItem = 2, Descripcion = "Autenticación de dos factores activada" },
        new Item { IdItem = 3, Descripcion = "Antivirus actualizado en todos los equipos" },
        new Item { IdItem = 4, Descripcion = "Capacitación anual en seguridad informática" },
        new Item { IdItem = 5, Descripcion = "Políticas claras sobre uso de dispositivos" },
    };

    public List<Pregunta> ListaPreguntas { get; } = new List<Pregunta>
{
    new Pregunta
    {
        IdPregunta = 1,
        Texto = "¿Las instalaciones están limpias?",
        Seccion = new Seccion { IdSeccion = 3, Nombre = "Limpieza" },
        Items = new List<Item>
        {
            new Item { IdItem = 1, Descripcion = "Pisos limpios" },
            new Item { IdItem = 2, Descripcion = "Ventanas limpias" }
        }
    },
    new Pregunta
    {
        IdPregunta = 2,
        Texto = "¿Se cuenta con salidas de emergencia?",
        Seccion = new Seccion { IdSeccion = 2, Nombre = "Seguridad" },
        Items = new List<Item>
        {
            new Item { IdItem = 3, Descripcion = "Extintores disponibles" },
            new Item { IdItem = 4, Descripcion = "Señalización visible" }
        }
    },
    new Pregunta
    {
        IdPregunta = 3,
        Texto = "¿Se cumplen las normas de seguridad?",
        Seccion = new Seccion { IdSeccion = 2, Nombre = "Seguridad" },
        Items = new List<Item>
        {
            new Item { IdItem = 3, Descripcion = "Extintores disponibles" },
            new Item { IdItem = 4, Descripcion = "Señalización visible" }
        }
    }
};


    public List<UbicacionInstitucional> ListaUbicacionInstitucional { get; } = new List<UbicacionInstitucional>
    {
        new UbicacionInstitucional
        {
            IdUbicacionInstitucional = 1,
            Ubicacion = new Ubicacion { IdUbicacion = 1 },
            Facultad = new Facultad { IdFacultad = 1 },
            Departamento = new Departamento { IdDepartamento = 1 }
        },
        new UbicacionInstitucional
        {
            IdUbicacionInstitucional = 2,
            Ubicacion = new Ubicacion { IdUbicacion = 2 },
            Facultad = new Facultad { IdFacultad = 2 },
            Departamento = new Departamento { IdDepartamento = 2 }
        },
        new UbicacionInstitucional
        {
            IdUbicacionInstitucional = 3,
            Ubicacion = new Ubicacion { IdUbicacion = 3 },
            Facultad = new Facultad { IdFacultad = 3 },
            Departamento = new Departamento { IdDepartamento = 3 }
        },
        new UbicacionInstitucional
        {
            IdUbicacionInstitucional = 4,
            Ubicacion = new Ubicacion { IdUbicacion = 4 },
            Facultad = new Facultad { IdFacultad = 4 },
            Departamento = new Departamento { IdDepartamento = 4 }
        },
    };

    public List<Auditoria> ListaAuditorias { get; } = new List<Auditoria>
    {
        new Auditoria { IdAuditoria = 1, Titulo = "Auditoría Seguridad Informática 2025", Ubicacion = new Ubicacion { IdUbicacion = 1 }, Fecha = new DateTime(2025, 8, 1) },
        new Auditoria { IdAuditoria = 2, Titulo = "Revisión Antivirus", Ubicacion = new Ubicacion { IdUbicacion = 2 }, Fecha = new DateTime(2025, 8, 2) },
        new Auditoria { IdAuditoria = 3, Titulo = "Capacitación Personal", Ubicacion = new Ubicacion { IdUbicacion = 3 }, Fecha = new DateTime(2025, 8, 3) },
    };

    public List<Encuesta> ListaEncuestas { get; } = new List<Encuesta>
    {
        new Encuesta { IdEncuesta = 1, IdAuditoria = 1, IdPersona = 1, FechaRealizacion = new DateTime(2025, 8, 1) },
        new Encuesta { IdEncuesta = 2, IdAuditoria = 2, IdPersona = 2, FechaRealizacion = new DateTime(2025, 8, 2) },
        new Encuesta { IdEncuesta = 3, IdAuditoria = 3, IdPersona = 3, FechaRealizacion = new DateTime(2025, 8, 3) },
    };

    public List<Respuesta> ListaRespuestas { get; } = new List<Respuesta>
    {
        new Respuesta { IdRespuesta = 1, Marcado = true, PorcentajeCumplimiento = "100%" },
        new Respuesta { IdRespuesta = 2, Marcado = false, PorcentajeCumplimiento = "50%" },
        new Respuesta { IdRespuesta = 3, Marcado = true, PorcentajeCumplimiento = "90%" },
    };

    public List<Seguimiento> ListaSeguimientos { get; } = new List<Seguimiento>
    {
        new Seguimiento
        {
            IdSeguimiento = 1,
            Item = new Item { IdItem = 1 },
            Estado = "Completado",
            Descripcion = "Contraseñas verificadas y aprobadas",
            Supervisor = "Luis Gómez",
            ResponsableTratamiento = "Carlos Ruiz",
            ResponsableImplementacion = "Ana Pérez",
            Evidencia = "Captura pantalla gestor de contraseñas",
            FechaInicio = new DateTime(2025, 8, 5),
            FechaFin = new DateTime(2025, 8, 10),
            ObservacionEstado = "Todo conforme"
        },
        new Seguimiento
        {
            IdSeguimiento = 2,
            Item = new Item { IdItem = 3 },
            Estado = "Pendiente",
            Descripcion = "Actualización antivirus programada",
            Supervisor = "Sofía Díaz",
            ResponsableTratamiento = "Luis Gómez",
            ResponsableImplementacion = "Carlos Ruiz",
            Evidencia = "Plan de actualización",
            FechaInicio = new DateTime(2025, 8, 6),
            FechaFin = new DateTime(2025, 8, 12),
            ObservacionEstado = "En espera"
        },
    };
        */
    }
}
