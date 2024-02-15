DROP TABLE IF EXISTS "order" CASCADE;

CREATE TABLE "order" (
	id uuid NOT NULL,
	status int NOT NULL,
	total_price money NOT NULL,
	notes varchar(250) NOT NULL,
	CONSTRAINT order_pk PRIMARY KEY (id)
);

INSERT INTO "order" (id, email, first_name, last_name) VALUES ('78000985-c789-439a-9714-821f36c9c051', 'sinan_akyazici@hotmail.com', 'Sinan', 'AKYAZICI');
