select * from anoescolar
select * from grado
USE BDAsistencia
GO
-- Tables:
CREATE TABLE anoescolar (
  aeid  INT  IDENTITY(1, 1) NOT NULL,
  aenombre nvarchar(4) NOT NULL,
  aeestado BIT NOT NULL,
  aefecfin  DATETIME NOT NULL,
  aefecini  DATETIME NOT NULL,  
  CONSTRAINT ano_pk PRIMARY KEY(aeid)
) 
GO
INSERT INTO cursodocente VALUES (1,1,'2024/02/12')
INSERT INTO cursodocente VALUES (1,2,'2024/02/15')
INSERT INTO cursodocente VALUES (2,1,'2024/02/14')
INSERT INTO cursodocente VALUES (3,3,'2024/02/13')
go
CREATE TABLE grado (
  grdid INT NOT NULL IDENTITY(1, 1),
  grdestado BIT NOT NULL,
  grdnombre nvarchar(50) NOT NULL,
  aeid   INT NOT NULL,
  CONSTRAINT grado_pk PRIMARY KEY(grdid)
)
GO
CREATE TABLE curso (
  curid  INT  NOT NULL IDENTITY(1, 1),
  curestado  BIT NOT NULL,  
  curnombre nvarchar(120) NOT NULL,
  grdid   INT NOT NULL,
  CONSTRAINT curso_pk PRIMARY KEY(curid)
)
GO
-----
CREATE TABLE cursodocente (
  curid  INT NOT NULL,
  docid  INT NOT NULL,  
  cdfecasig  DATETIME NOT NULL DEFAULT getdate(),
  CONSTRAINT curdoc_pk PRIMARY KEY(curid,docid)  
)
GO

CREATE TABLE horariodoc (
    hcid   INT  NOT NULL IDENTITY(1, 1),
    hcdia  nvarchar(20) NOT NULL,
    hchoraini  TIME NOT NULL,
    hchorafin  TIME NOT NULL,
    curid    INT NOT NULL,
    docid    INT NOT NULL,  
   CONSTRAINT hora_pk PRIMARY KEY(hcid)   
)
INSERT INTO horariodoc VALUES ('lunes','10','12',1,1);
INSERT INTO horariodoc VALUES ('martes','08','10',1,2);
INSERT INTO horariodoc VALUES ('miercoles','09','10',2,1);
INSERT INTO horariodoc VALUES ('jueves','10','11',3,3);

CREATE TABLE asistenciadoc (
   fdpid     INT NOT NULL IDENTITY(1, 1),
   fdpestado  BIT NOT NULL DEFAULT 1,
   fdpfecha   DATETIME NOT NULL,
   hcid       INT  NOT NULL,
   asmarca    BIT  NULL DEFAULT 0,
   marcamomento  DATETIME NULL,  
   CONSTRAINT  fdp_pk PRIMARY KEY(fdpid) 
)
GO


CREATE TABLE alumno (
   aluid   INT NOT NULL IDENTITY(1, 1),
   aluestado  BIT NOT NULL,
   dni nvarchar(8) NULL,
   FechaRegistro  DATETIME NOT NULL DEFAULT getdate(),
   apellidomat nvarchar(80) NOT NULL,
   apellidopat nvarchar(80) NOT NULL,  
   direccion nvarchar(100) NOT NULL,  
   genero BIT NOT NULL,
   nombres nvarchar(100) NOT NULL,       
   CONSTRAINT alumno_pk PRIMARY KEY(aluid)
)
GO
CREATE TABLE asistenciaalu (   
   fecid   INT NOT NULL IDENTITY(1, 1),
   fecano   DATETIME NOT NULL,
   marcacion   nvarchar(70) NULL,
   docid    INT NOT NULL,
   aluid    INT NOT NULL,
   fecestado  BIT NOT NULL,
   CONSTRAINT fecha_pk PRIMARY KEY(fecid)   
)
GO
CREATE TABLE docente (
   docid   INT IDENTITY(1,1) NOT NULL,
   docestado  BIT NOT NULL,
   dni nvarchar(8) NOT NULL,
   FechaRegistro  DATETIME NOT NULL DEFAULT getdate(),
   apellidomat nvarchar(70) NOT NULL,
   apellidopat nvarchar(70) NOT NULL,  
   direccion nvarchar(100) NOT NULL,  
   genero BIT NOT NULL,
   nombres nvarchar(100) NOT NULL,       
   CONSTRAINT docente_pk PRIMARY KEY(docid)
)
insert into alumno values(1,'54125','2022/02/10','mili','Remo','lomas 20',1,'maria');

-- Foreing Keys:
-- Reference: FK1(table: grado)
ALTER TABLE grado ADD CONSTRAINT FK1 FOREIGN KEY(aeid)
    REFERENCES anoescolar(aeid)
	GO

-- Reference: FK2(table: curso)
ALTER TABLE curso ADD CONSTRAINT FK2 FOREIGN KEY(grdid)
    REFERENCES grado(grdid)
	GO

-- Reference: FK3(table: curso_docente)
ALTER TABLE cursodocente ADD CONSTRAINT FK3 FOREIGN KEY(curid)
    REFERENCES curso(curid)
	GO
ALTER TABLE cursodocente ADD CONSTRAINT FK4 FOREIGN KEY(docid)
    REFERENCES docente(docid)
	GO
-- Reference: FK5(table: horario_curso)
ALTER TABLE horariodoc ADD CONSTRAINT FK5 FOREIGN KEY(curid,docid)
    REFERENCES cursodocente(curid,docid)
	GO
-----
ALTER TABLE asistenciadoc ADD CONSTRAINT FK6 FOREIGN KEY(hcid)
    REFERENCES horariodoc(hcid)
	GO
-----

---
ALTER TABLE asistenciaalu ADD CONSTRAINT FK7 FOREIGN KEY(docid)
    REFERENCES docente(docid)
	GO
ALTER TABLE asistenciaalu ADD CONSTRAINT FK8 FOREIGN KEY(aluid)
    REFERENCES alumno(aluid)
	GO
