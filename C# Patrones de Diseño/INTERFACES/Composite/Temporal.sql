WITH recursivo AS (
    SELECT
        sp2.id_permiso_padre,
        sp2.id_permiso_hijo
    FROM
        permiso_permiso SP2
    WHERE
        sp2.id_permiso_padre {
    WHERE
        } --acá se va variando la familia que busco
    UNION
    ALL
    SELECT
        sp.id_permiso_padre,
        sp.id_permiso_hijo
    FROM
        permiso_permiso sp
        INNER JOIN recursivo r ON r.id_permiso_hijo = sp.id_permiso_padre
)
SELECT
    r.id_permiso_padre,
    r.id_permiso_hijo,
    p.id,
    p.nombre,
    p.es_patente
FROM
    recursivo r
    INNER JOIN permiso p ON r.id_permiso_hijo = p.id