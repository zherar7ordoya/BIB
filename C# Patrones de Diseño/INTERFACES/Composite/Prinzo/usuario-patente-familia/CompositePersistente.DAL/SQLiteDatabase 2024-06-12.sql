BEGIN TRANSACTION;

CREATE TABLE

IF NOT EXISTS "permiso" (
		"nombre" VARCHAR(100) COLLATE NOCASE,
		"id" INTEGER NOT NULL,
		"permiso" VARCHAR(50) COLLATE NOCASE,
		PRIMARY KEY ("id" AUTOINCREMENT)
		);
	CREATE TABLE

IF NOT EXISTS "permiso_permiso" (
		"id_permiso_padre" INTEGER,
		"id_permiso_hijo" INTEGER,
		FOREIGN KEY ("id_permiso_padre") REFERENCES "permiso" ("id"),
		FOREIGN KEY ("id_permiso_hijo") REFERENCES "permiso" ("id")
		);
	CREATE TABLE

IF NOT EXISTS "usuarios" (
		"id_usuario" INTEGER NOT NULL,
		"nombre" VARCHAR(100) COLLATE NOCASE,
		PRIMARY KEY ("id_usuario")
		);
	CREATE TABLE

IF NOT EXISTS "usuarios_permisos" (
		"id_usuario" INTEGER NOT NULL,
		"id_permiso" INTEGER NOT NULL,
		PRIMARY KEY (
			"id_usuario",
			"id_permiso"
			),
		FOREIGN KEY ("id_usuario") REFERENCES "usuarios" ("id_usuario"),
		FOREIGN KEY ("id_permiso") REFERENCES "permiso" ("id")
		);
	INSERT INTO "permiso"
	VALUES (
		'MenuF',
		5002,
		'PuedeHacerF'
		);

INSERT INTO "permiso"
VALUES (
	'SubMenuA',
	5003,
	'PuedeHacerA'
	);

INSERT INTO "permiso"
VALUES (
	'SubMenuG',
	5004,
	'PuedeHacerG'
	);

INSERT INTO "permiso"
VALUES (
	'SubMenuD',
	5005,
	'PuedeHacerD'
	);

INSERT INTO "permiso"
VALUES (
	'SubMenuB',
	5006,
	'PuedeHacerB'
	);

INSERT INTO "permiso"
VALUES (
	'Rol1',
	5007,
	NULL
	);

INSERT INTO "permiso"
VALUES (
	'Rol2',
	5008,
	NULL
	);

INSERT INTO "permiso"
VALUES (
	'Rol3',
	5009,
	NULL
	);

INSERT INTO "permiso"
VALUES (
	'SubmenuA',
	5011,
	'PuedeHacerA'
	);

INSERT INTO "permiso"
VALUES (
	'SubMenuC',
	5012,
	'PuedeHacerC'
	);

INSERT INTO "permiso_permiso"
VALUES (
	5007,
	5002
	);

INSERT INTO "permiso_permiso"
VALUES (
	5007,
	5003
	);

INSERT INTO "permiso_permiso"
VALUES (
	5008,
	5004
	);

INSERT INTO "permiso_permiso"
VALUES (
	5008,
	5006
	);

INSERT INTO "permiso_permiso"
VALUES (
	5009,
	5002
	);

INSERT INTO "permiso_permiso"
VALUES (
	5009,
	5011
	);

INSERT INTO "permiso_permiso"
VALUES (
	5009,
	5008
	);

INSERT INTO "usuarios"
VALUES (
	1,
	'Juan'
	);

INSERT INTO "usuarios"
VALUES (
	2,
	'Nico'
	);

INSERT INTO "usuarios"
VALUES (
	3,
	'Natalia'
	);

INSERT INTO "usuarios"
VALUES (
	7,
	'Gerardo'
	);

INSERT INTO "usuarios_permisos"
VALUES (
	2,
	5005
	);

INSERT INTO "usuarios_permisos"
VALUES (
	2,
	5007
	);

INSERT INTO "usuarios_permisos"
VALUES (
	3,
	5002
	);

INSERT INTO "usuarios_permisos"
VALUES (
	3,
	5008
	);

INSERT INTO "usuarios_permisos"
VALUES (
	7,
	5005
	);

INSERT INTO "usuarios_permisos"
VALUES (
	7,
	5006
	);

INSERT INTO "usuarios_permisos"
VALUES (
	7,
	5007
	);

INSERT INTO "usuarios_permisos"
VALUES (
	7,
	5009
	);

INSERT INTO "usuarios_permisos"
VALUES (
	7,
	5012
	);

COMMIT;
