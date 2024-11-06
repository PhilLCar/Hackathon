-- Database: HackathonTest

-- DROP DATABASE IF EXISTS "HackathonTest";

CREATE DATABASE "HackathonTest"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_Canada.1252'
    LC_CTYPE = 'English_Canada.1252'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

-- Table: public.Fields

-- DROP TABLE IF EXISTS public."Fields";

CREATE TABLE IF NOT EXISTS public."Fields"
(
    "Id" integer NOT NULL DEFAULT nextval('fields_id_seq'::regclass),
    "Name" character varying(25) COLLATE pg_catalog."default" NOT NULL,
    "Description" character varying(100) COLLATE pg_catalog."default",
    CONSTRAINT fields_pkey PRIMARY KEY ("Id"),
    CONSTRAINT fields_name_key UNIQUE ("Name")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Fields"
    OWNER to postgres;

-- Table: public.FormFields

-- DROP TABLE IF EXISTS public."FormFields";

CREATE TABLE IF NOT EXISTS public."FormFields"
(
    "Id" integer NOT NULL DEFAULT nextval('formfields_id_seq'::regclass),
    "FieldId" integer NOT NULL,
    "FormSectionId" integer NOT NULL,
    "Name" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT formfields_pkey PRIMARY KEY ("Id"),
    CONSTRAINT "FormFields_Name_FormSectionId_key" UNIQUE ("Name", "FormSectionId"),
    CONSTRAINT formfields_fieldid_fkey FOREIGN KEY ("FieldId")
        REFERENCES public."Fields" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT formfields_roleid_fkey FOREIGN KEY ("FormSectionId")
        REFERENCES public."FormSections" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."FormFields"
    OWNER to postgres;

-- Table: public.Forms

-- DROP TABLE IF EXISTS public."Forms";

CREATE TABLE IF NOT EXISTS public."Forms"
(
    "Id" integer NOT NULL DEFAULT nextval('forms_id_seq'::regclass),
    "Name" character varying(25) COLLATE pg_catalog."default" NOT NULL,
    "Description" character varying(100) COLLATE pg_catalog."default",
    CONSTRAINT forms_pkey PRIMARY KEY ("Id"),
    CONSTRAINT forms_name_key UNIQUE ("Name")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Forms"
    OWNER to postgres;

-- Table: public.MemberFields

-- DROP TABLE IF EXISTS public."MemberFields";

CREATE TABLE IF NOT EXISTS public."MemberFields"
(
    "Id" integer NOT NULL DEFAULT nextval('memberfields_id_seq'::regclass),
    "MemberId" integer NOT NULL,
    "FieldId" integer NOT NULL,
    "Value" character varying(100) COLLATE pg_catalog."default",
    CONSTRAINT memberfields_pkey PRIMARY KEY ("Id"),
    CONSTRAINT memberfields_fieldid_fkey FOREIGN KEY ("FieldId")
        REFERENCES public."Fields" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT memberfields_memberid_fkey FOREIGN KEY ("MemberId")
        REFERENCES public."Members" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."MemberFields"
    OWNER to postgres;

-- Table: public.Members

-- DROP TABLE IF EXISTS public."Members";

CREATE TABLE IF NOT EXISTS public."Members"
(
    "Id" integer NOT NULL DEFAULT nextval('members_id_seq'::regclass),
    "Email" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT members_pkey PRIMARY KEY ("Id"),
    CONSTRAINT members_email_key UNIQUE ("Email")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Members"
    OWNER to postgres;

-- Table: public.FormSections

-- DROP TABLE IF EXISTS public."FormSections";

CREATE TABLE IF NOT EXISTS public."FormSections"
(
    "Id" integer NOT NULL DEFAULT nextval('roles_id_seq'::regclass),
    "Name" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "FormId" integer NOT NULL,
    CONSTRAINT roles_pkey PRIMARY KEY ("Id"),
    CONSTRAINT roles_name_key UNIQUE ("Name"),
    CONSTRAINT "Roles_FormId_fkey" FOREIGN KEY ("FormId")
        REFERENCES public."Forms" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."FormSections"
    OWNER to postgres;

-- Table: public.TransactionFields

-- DROP TABLE IF EXISTS public."TransactionFields";

CREATE TABLE IF NOT EXISTS public."TransactionFields"
(
    "Id" integer NOT NULL DEFAULT nextval('transactionfields_id_seq'::regclass),
    "TransactionId" integer NOT NULL,
    "FormFieldId" integer NOT NULL,
    "Value" character varying(100) COLLATE pg_catalog."default",
    CONSTRAINT transactionfields_pkey PRIMARY KEY ("Id"),
    CONSTRAINT transactionfields_formfieldid_fkey FOREIGN KEY ("FormFieldId")
        REFERENCES public."FormFields" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT transactionfields_transactionid_fkey FOREIGN KEY ("TransactionId")
        REFERENCES public."Transactions" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TransactionFields"
    OWNER to postgres;

-- Table: public.TransactionOwners

-- DROP TABLE IF EXISTS public."TransactionOwners";

CREATE TABLE IF NOT EXISTS public."TransactionOwners"
(
    "Id" integer NOT NULL DEFAULT nextval('transactionowners_id_seq'::regclass),
    "TransactionId" integer NOT NULL,
    "OwnerId" integer,
    "Date" timestamp without time zone NOT NULL DEFAULT now(),
    "SectionId" integer NOT NULL,
    CONSTRAINT transactionowners_pkey PRIMARY KEY ("Id"),
    CONSTRAINT transactionowners_ownasid_fkey FOREIGN KEY ("SectionId")
        REFERENCES public."FormSections" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT transactionowners_ownerid_fkey FOREIGN KEY ("OwnerId")
        REFERENCES public."Members" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT transactionowners_transactionid_fkey FOREIGN KEY ("TransactionId")
        REFERENCES public."Transactions" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TransactionOwners"
    OWNER to postgres;

-- Table: public.Transactions

-- DROP TABLE IF EXISTS public."Transactions";

CREATE TABLE IF NOT EXISTS public."Transactions"
(
    "Id" integer NOT NULL DEFAULT nextval('transactions_id_seq'::regclass),
    "FormId" integer NOT NULL,
    "CreatedById" integer NOT NULL,
    "CreatedOn" timestamp without time zone NOT NULL DEFAULT now(),
    "Done" boolean NOT NULL DEFAULT false,
    CONSTRAINT transactions_pkey PRIMARY KEY ("Id"),
    CONSTRAINT transactions_createdbyid_fkey FOREIGN KEY ("CreatedById")
        REFERENCES public."Members" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT transactions_formid_fkey FOREIGN KEY ("FormId")
        REFERENCES public."Forms" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Transactions"
    OWNER to postgres;