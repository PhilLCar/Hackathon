--
-- PostgreSQL database dump
--

-- Dumped from database version 17.0
-- Dumped by pg_dump version 17.0

-- Started on 2024-11-07 15:30:04

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 220 (class 1259 OID 16406)
-- Name: Fields; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Fields" (
    "Id" integer NOT NULL,
    "Name" character varying(25) NOT NULL,
    "Description" character varying(100)
);


ALTER TABLE public."Fields" OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 16424)
-- Name: FormFields; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."FormFields" (
    "Id" integer NOT NULL,
    "FieldId" integer NOT NULL,
    "FormSectionId" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);


ALTER TABLE public."FormFields" OWNER TO postgres;

--
-- TOC entry 236 (class 1259 OID 16574)
-- Name: FormInputs; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."FormInputs" (
    "Id" integer NOT NULL,
    "Name" character varying(25) NOT NULL,
    "FormSectionId" integer NOT NULL
);


ALTER TABLE public."FormInputs" OWNER TO postgres;

--
-- TOC entry 235 (class 1259 OID 16573)
-- Name: FormInputs_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."FormInputs_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."FormInputs_Id_seq" OWNER TO postgres;

--
-- TOC entry 4944 (class 0 OID 0)
-- Dependencies: 235
-- Name: FormInputs_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."FormInputs_Id_seq" OWNED BY public."FormInputs"."Id";


--
-- TOC entry 232 (class 1259 OID 16526)
-- Name: FormSections; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."FormSections" (
    "Id" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "FormId" integer NOT NULL
);


ALTER TABLE public."FormSections" OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 16397)
-- Name: Forms; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Forms" (
    "Id" integer NOT NULL,
    "Name" character varying(25) NOT NULL,
    "Description" character varying(100)
);


ALTER TABLE public."Forms" OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 16491)
-- Name: MemberFields; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."MemberFields" (
    "Id" integer NOT NULL,
    "MemberId" integer NOT NULL,
    "FieldId" integer NOT NULL,
    "Value" character varying(100)
);


ALTER TABLE public."MemberFields" OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 16415)
-- Name: Members; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Members" (
    "Id" integer NOT NULL,
    "Email" character varying(50) NOT NULL
);


ALTER TABLE public."Members" OWNER TO postgres;

--
-- TOC entry 234 (class 1259 OID 16545)
-- Name: TransactionFields; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."TransactionFields" (
    "Id" integer NOT NULL,
    "TransactionId" integer NOT NULL,
    "FormFieldId" integer NOT NULL,
    "Value" character varying(100)
);


ALTER TABLE public."TransactionFields" OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 16508)
-- Name: TransactionOwners; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."TransactionOwners" (
    "Id" integer NOT NULL,
    "TransactionId" integer NOT NULL,
    "OwnerId" integer,
    "Date" timestamp without time zone DEFAULT now() NOT NULL,
    "FormSectionId" integer
);


ALTER TABLE public."TransactionOwners" OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 16472)
-- Name: Transactions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Transactions" (
    "Id" integer NOT NULL,
    "FormId" integer NOT NULL,
    "CreatedById" integer NOT NULL,
    "CreatedOn" timestamp without time zone DEFAULT now() NOT NULL,
    "Done" boolean DEFAULT false NOT NULL
);


ALTER TABLE public."Transactions" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16405)
-- Name: fields_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.fields_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.fields_id_seq OWNER TO postgres;

--
-- TOC entry 4945 (class 0 OID 0)
-- Dependencies: 219
-- Name: fields_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.fields_id_seq OWNED BY public."Fields"."Id";


--
-- TOC entry 223 (class 1259 OID 16423)
-- Name: formfields_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.formfields_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.formfields_id_seq OWNER TO postgres;

--
-- TOC entry 4946 (class 0 OID 0)
-- Dependencies: 223
-- Name: formfields_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.formfields_id_seq OWNED BY public."FormFields"."Id";


--
-- TOC entry 217 (class 1259 OID 16396)
-- Name: forms_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.forms_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.forms_id_seq OWNER TO postgres;

--
-- TOC entry 4947 (class 0 OID 0)
-- Dependencies: 217
-- Name: forms_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.forms_id_seq OWNED BY public."Forms"."Id";


--
-- TOC entry 227 (class 1259 OID 16490)
-- Name: memberfields_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.memberfields_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.memberfields_id_seq OWNER TO postgres;

--
-- TOC entry 4948 (class 0 OID 0)
-- Dependencies: 227
-- Name: memberfields_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.memberfields_id_seq OWNED BY public."MemberFields"."Id";


--
-- TOC entry 221 (class 1259 OID 16414)
-- Name: members_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.members_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.members_id_seq OWNER TO postgres;

--
-- TOC entry 4949 (class 0 OID 0)
-- Dependencies: 221
-- Name: members_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.members_id_seq OWNED BY public."Members"."Id";


--
-- TOC entry 231 (class 1259 OID 16525)
-- Name: roles_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.roles_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.roles_id_seq OWNER TO postgres;

--
-- TOC entry 4950 (class 0 OID 0)
-- Dependencies: 231
-- Name: roles_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.roles_id_seq OWNED BY public."FormSections"."Id";


--
-- TOC entry 233 (class 1259 OID 16544)
-- Name: transactionfields_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.transactionfields_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.transactionfields_id_seq OWNER TO postgres;

--
-- TOC entry 4951 (class 0 OID 0)
-- Dependencies: 233
-- Name: transactionfields_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.transactionfields_id_seq OWNED BY public."TransactionFields"."Id";


--
-- TOC entry 229 (class 1259 OID 16507)
-- Name: transactionowners_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.transactionowners_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.transactionowners_id_seq OWNER TO postgres;

--
-- TOC entry 4952 (class 0 OID 0)
-- Dependencies: 229
-- Name: transactionowners_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.transactionowners_id_seq OWNED BY public."TransactionOwners"."Id";


--
-- TOC entry 225 (class 1259 OID 16471)
-- Name: transactions_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.transactions_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.transactions_id_seq OWNER TO postgres;

--
-- TOC entry 4953 (class 0 OID 0)
-- Dependencies: 225
-- Name: transactions_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.transactions_id_seq OWNED BY public."Transactions"."Id";


--
-- TOC entry 4741 (class 2604 OID 16409)
-- Name: Fields Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Fields" ALTER COLUMN "Id" SET DEFAULT nextval('public.fields_id_seq'::regclass);


--
-- TOC entry 4743 (class 2604 OID 16427)
-- Name: FormFields Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FormFields" ALTER COLUMN "Id" SET DEFAULT nextval('public.formfields_id_seq'::regclass);


--
-- TOC entry 4752 (class 2604 OID 16577)
-- Name: FormInputs Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FormInputs" ALTER COLUMN "Id" SET DEFAULT nextval('public."FormInputs_Id_seq"'::regclass);


--
-- TOC entry 4750 (class 2604 OID 16529)
-- Name: FormSections Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FormSections" ALTER COLUMN "Id" SET DEFAULT nextval('public.roles_id_seq'::regclass);


--
-- TOC entry 4740 (class 2604 OID 16400)
-- Name: Forms Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Forms" ALTER COLUMN "Id" SET DEFAULT nextval('public.forms_id_seq'::regclass);


--
-- TOC entry 4747 (class 2604 OID 16494)
-- Name: MemberFields Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MemberFields" ALTER COLUMN "Id" SET DEFAULT nextval('public.memberfields_id_seq'::regclass);


--
-- TOC entry 4742 (class 2604 OID 16418)
-- Name: Members Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Members" ALTER COLUMN "Id" SET DEFAULT nextval('public.members_id_seq'::regclass);


--
-- TOC entry 4751 (class 2604 OID 16548)
-- Name: TransactionFields Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TransactionFields" ALTER COLUMN "Id" SET DEFAULT nextval('public.transactionfields_id_seq'::regclass);


--
-- TOC entry 4748 (class 2604 OID 16511)
-- Name: TransactionOwners Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TransactionOwners" ALTER COLUMN "Id" SET DEFAULT nextval('public.transactionowners_id_seq'::regclass);


--
-- TOC entry 4744 (class 2604 OID 16475)
-- Name: Transactions Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Transactions" ALTER COLUMN "Id" SET DEFAULT nextval('public.transactions_id_seq'::regclass);


--
-- TOC entry 4766 (class 2606 OID 16587)
-- Name: FormFields FormFields_Name_FormSectionId_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FormFields"
    ADD CONSTRAINT "FormFields_Name_FormSectionId_key" UNIQUE ("Name", "FormSectionId");


--
-- TOC entry 4780 (class 2606 OID 16579)
-- Name: FormInputs FormInputs_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FormInputs"
    ADD CONSTRAINT "FormInputs_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 4758 (class 2606 OID 16413)
-- Name: Fields fields_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Fields"
    ADD CONSTRAINT fields_name_key UNIQUE ("Name");


--
-- TOC entry 4760 (class 2606 OID 16411)
-- Name: Fields fields_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Fields"
    ADD CONSTRAINT fields_pkey PRIMARY KEY ("Id");


--
-- TOC entry 4768 (class 2606 OID 16429)
-- Name: FormFields formfields_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FormFields"
    ADD CONSTRAINT formfields_pkey PRIMARY KEY ("Id");


--
-- TOC entry 4754 (class 2606 OID 16404)
-- Name: Forms forms_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Forms"
    ADD CONSTRAINT forms_name_key UNIQUE ("Name");


--
-- TOC entry 4756 (class 2606 OID 16402)
-- Name: Forms forms_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Forms"
    ADD CONSTRAINT forms_pkey PRIMARY KEY ("Id");


--
-- TOC entry 4772 (class 2606 OID 16496)
-- Name: MemberFields memberfields_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MemberFields"
    ADD CONSTRAINT memberfields_pkey PRIMARY KEY ("Id");


--
-- TOC entry 4762 (class 2606 OID 16422)
-- Name: Members members_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Members"
    ADD CONSTRAINT members_email_key UNIQUE ("Email");


--
-- TOC entry 4764 (class 2606 OID 16420)
-- Name: Members members_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Members"
    ADD CONSTRAINT members_pkey PRIMARY KEY ("Id");


--
-- TOC entry 4776 (class 2606 OID 16531)
-- Name: FormSections roles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FormSections"
    ADD CONSTRAINT roles_pkey PRIMARY KEY ("Id");


--
-- TOC entry 4778 (class 2606 OID 16550)
-- Name: TransactionFields transactionfields_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TransactionFields"
    ADD CONSTRAINT transactionfields_pkey PRIMARY KEY ("Id");


--
-- TOC entry 4774 (class 2606 OID 16514)
-- Name: TransactionOwners transactionowners_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TransactionOwners"
    ADD CONSTRAINT transactionowners_pkey PRIMARY KEY ("Id");


--
-- TOC entry 4770 (class 2606 OID 16479)
-- Name: Transactions transactions_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Transactions"
    ADD CONSTRAINT transactions_pkey PRIMARY KEY ("Id");


--
-- TOC entry 4793 (class 2606 OID 16580)
-- Name: FormInputs FormInputs_FormSectionId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FormInputs"
    ADD CONSTRAINT "FormInputs_FormSectionId_fkey" FOREIGN KEY ("FormSectionId") REFERENCES public."FormSections"("Id");


--
-- TOC entry 4790 (class 2606 OID 16561)
-- Name: FormSections Roles_FormId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FormSections"
    ADD CONSTRAINT "Roles_FormId_fkey" FOREIGN KEY ("FormId") REFERENCES public."Forms"("Id");


--
-- TOC entry 4781 (class 2606 OID 16435)
-- Name: FormFields formfields_fieldid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FormFields"
    ADD CONSTRAINT formfields_fieldid_fkey FOREIGN KEY ("FieldId") REFERENCES public."Fields"("Id");


--
-- TOC entry 4782 (class 2606 OID 16534)
-- Name: FormFields formfields_roleid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FormFields"
    ADD CONSTRAINT formfields_roleid_fkey FOREIGN KEY ("FormSectionId") REFERENCES public."FormSections"("Id");


--
-- TOC entry 4785 (class 2606 OID 16502)
-- Name: MemberFields memberfields_fieldid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MemberFields"
    ADD CONSTRAINT memberfields_fieldid_fkey FOREIGN KEY ("FieldId") REFERENCES public."Fields"("Id");


--
-- TOC entry 4786 (class 2606 OID 16497)
-- Name: MemberFields memberfields_memberid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MemberFields"
    ADD CONSTRAINT memberfields_memberid_fkey FOREIGN KEY ("MemberId") REFERENCES public."Members"("Id");


--
-- TOC entry 4791 (class 2606 OID 16556)
-- Name: TransactionFields transactionfields_formfieldid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TransactionFields"
    ADD CONSTRAINT transactionfields_formfieldid_fkey FOREIGN KEY ("FormFieldId") REFERENCES public."FormFields"("Id");


--
-- TOC entry 4792 (class 2606 OID 16551)
-- Name: TransactionFields transactionfields_transactionid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TransactionFields"
    ADD CONSTRAINT transactionfields_transactionid_fkey FOREIGN KEY ("TransactionId") REFERENCES public."Transactions"("Id");


--
-- TOC entry 4787 (class 2606 OID 16539)
-- Name: TransactionOwners transactionowners_ownasid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TransactionOwners"
    ADD CONSTRAINT transactionowners_ownasid_fkey FOREIGN KEY ("FormSectionId") REFERENCES public."FormSections"("Id");


--
-- TOC entry 4788 (class 2606 OID 16520)
-- Name: TransactionOwners transactionowners_ownerid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TransactionOwners"
    ADD CONSTRAINT transactionowners_ownerid_fkey FOREIGN KEY ("OwnerId") REFERENCES public."Members"("Id");


--
-- TOC entry 4789 (class 2606 OID 16515)
-- Name: TransactionOwners transactionowners_transactionid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TransactionOwners"
    ADD CONSTRAINT transactionowners_transactionid_fkey FOREIGN KEY ("TransactionId") REFERENCES public."Transactions"("Id");


--
-- TOC entry 4783 (class 2606 OID 16485)
-- Name: Transactions transactions_createdbyid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Transactions"
    ADD CONSTRAINT transactions_createdbyid_fkey FOREIGN KEY ("CreatedById") REFERENCES public."Members"("Id");


--
-- TOC entry 4784 (class 2606 OID 16480)
-- Name: Transactions transactions_formid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Transactions"
    ADD CONSTRAINT transactions_formid_fkey FOREIGN KEY ("FormId") REFERENCES public."Forms"("Id");


-- Completed on 2024-11-07 15:30:04

--
-- PostgreSQL database dump complete
--

