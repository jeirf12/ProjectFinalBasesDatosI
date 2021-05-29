/*==============================================================*/
/* DBMS name:      ORACLE Version 11g                           */
/* Created on:     19/03/2020 8:25:28 a. m.                     */
/*==============================================================*/


drop table CAMARA_COMERCIO cascade constraints;

drop table DOMICILIARIO cascade constraints;

drop table EMPRESA_DOMICILIARIA cascade constraints;

drop table TRABAJA cascade constraints;

/*==============================================================*/
/* Table: CAMARA_COMERCIO                                       */
/*==============================================================*/
create table CAMARA_COMERCIO 
(
   CAM_NIT              VARCHAR2(20)         not null,
   CAM_NOMBRE           VARCHAR2(30)         not null,
   constraint PK_CAMARA_COMERCIO primary key (CAM_NIT)
);

/*==============================================================*/
/* Table: DOMICILIARIO                                          */
/*==============================================================*/
create table DOMICILIARIO 
(
   DOM_ID               NUMBER(20)           not null,
   DOM_NOMBRE           VARCHAR2(30)         not null,
   DOM_APELLIDO         VARCHAR2(30)         not null,
   DOM_ANIOEXPERIENCIA  VARCHAR2(30)         not null,
   DOM_ESTADO           VARCHAR2(8)          not null,
   constraint PK_DOMICILIARIO primary key (DOM_ID),
   constraint CK_ESTADO check (DOM_ESTADO in ('activo','inactivo'))
);

/*==============================================================*/
/* Table: EMPRESA_DOMICILIARIA                                  */
/*==============================================================*/
create table EMPRESA_DOMICILIARIA 
(
   EMP_NIT              VARCHAR2(20)         not null,
   CAM_NIT              VARCHAR2(20)         not null,
   EMP_NOMBRE           VARCHAR2(30)         not null,
   EMP_FECHAOPERAR      DATE                 not null,
   constraint PK_EMPRESA_DOMICILIARIA primary key (EMP_NIT)
);

/*==============================================================*/
/* Table: TRABAJA                                               */
/*==============================================================*/
create table TRABAJA 
(
   EMP_NIT              VARCHAR2(20)         not null,
   DOM_ID               NUMBER(20)           not null,
   TRAB_FECHA_INICIO    DATE                 not null,
   TRAB_FECHA_FIN       DATE                 not null,                
   constraint PK_TRABAJA primary key (EMP_NIT, DOM_ID,TRAB_FECHA_INICIO,TRAB_FECHA_FIN)
);

alter table EMPRESA_DOMICILIARIA
   add constraint FK_EMPRESA_CAMARA_C foreign key (CAM_NIT)
      references CAMARA_COMERCIO (CAM_NIT);

alter table TRABAJA
   add constraint FK_TRABAJA_EMPRESA_DOM foreign key (EMP_NIT)
      references EMPRESA_DOMICILIARIA (EMP_NIT);

alter table TRABAJA
   add constraint FK_TRABAJA_DOMICILIARIO foreign key (DOM_ID)
      references DOMICILIARIO (DOM_ID);

