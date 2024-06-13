-- Selecciona todas las columnas de la tabla permiso.
SELECT
    permiso.*
-- Se realiza una unión interna (INNER JOIN) entre las tablas usuarios_permisos
-- y permiso donde la columna id_permiso de usuarios_permisos coincide con la
-- columna id de permiso.
FROM
    usuarios_permisos
    INNER JOIN permiso ON usuarios_permisos.id_permiso = permiso.id
-- Filtra los resultados para incluir solo aquellos registros donde id_usuario
-- en la tabla usuarios_permisos es igual al parámetro @id.
WHERE
    usuarios_permisos.id_usuario = @id