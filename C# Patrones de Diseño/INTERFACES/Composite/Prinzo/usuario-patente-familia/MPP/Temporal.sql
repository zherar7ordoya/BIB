WITH JerarquiaPermisos AS
(
    SELECT
        permiso_permiso.id_permiso_padre,
        permiso_permiso.id_permiso_hijo
    FROM
        permiso_permiso
    WHERE
        permiso_permiso.id_permiso_padre {
    WHERE
        } -- acá se va variando la familia que busco
    UNION
    ALL
    SELECT
        permiso_permiso.id_permiso_padre,
        permiso_permiso.id_permiso_hijo
    FROM
        permiso_permiso
        INNER JOIN JerarquiaPermisos
        ON JerarquiaPermisos.id_permiso_hijo = permiso_permiso.id_permiso_padre
)
SELECT
    JerarquiaPermisos.id_permiso_padre,
    JerarquiaPermisos.id_permiso_hijo,
    permiso.id,
    permiso.nombre,
    permiso.permiso
FROM
    JerarquiaPermisos
    INNER JOIN permiso
    ON JerarquiaPermisos.id_permiso_hijo = permiso.id