create table if not exists public.countries (
	id serial primary key,
	name varchar(100) not null unique,
	code varchar[2] not null unique
);

alter table public.countries alter column code type varchar(2);

create table if not exists public.authors (
	id serial primary key,
	name varchar(100) not null,
	surname varchar(100) not null,
	email varchar(100) not null unique,
	country_id integer references public.countries(id) not null,
	birthday date not null
);

alter table public.authors alter column country_id drop not null;

create table if not exists public.publishers (
	id serial primary key,
	name varchar(100) not null,
	address varchar(1000) not null,
	country_id integer references public.countries(id) not null
);

create table if not exists public.books (
	id serial primary key,
	title varchar(1000) not null,
	publish_date date not null,
	publisher_id integer references public.publishers(id),
	author_id integer references public.authors(id) not null
);

-- insert into public.countries(name, code) values
-- 	('Ukraine', 'UA'),
-- 	('Poland', 'PL');

-- insert into public.authors (name, surname, email, country_id, birthday) values
-- 	('Oleksii', 'K', 'some@email.com', 7, '03/30/1994');

-- insert into public.authors (name, surname, email, country_id, birthday) values
-- 	('Zorian', 'D', 'some2@email.com', 7, '11/11/1994'),
-- 	('Gregor', 'P', 'poland@email.com', 8, '9/11/1999');

-- insert into public.authors (name, surname, email, country_id, birthday) values
-- 	('John', 'Z', 'same@email.com', null, '11/11/1994'),
-- 	('Jack', 'P', 'cool@email.com', null, '9/11/1999');

-- insert into public.countries(name, code) values
-- 	('United States', 'US'),
-- 	('United Kingdom', 'UK');

select * from public.authors t1
	full join public.countries t2 on t1.country_id = t2.id;
