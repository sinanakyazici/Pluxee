DROP TABLE IF EXISTS customer CASCADE;

CREATE TABLE "customer" (
	id uuid NOT NULL,
	email varchar(50) NOT NULL,
	first_name varchar(50) NOT NULL,
	last_name varchar(50) NOT NULL,
	CONSTRAINT customer_pk PRIMARY KEY (id)
);

INSERT INTO "customer" (id, email, first_name, last_name) VALUES ('78000985-c789-439a-9714-821f36c9c051', 'sinan_akyazici@hotmail.com', 'Sinan', 'AKYAZICI');
