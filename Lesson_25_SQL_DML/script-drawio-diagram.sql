create table if not exists public.customers (
  id serial primary key,
  l_name varchar(100) not null,
  f_name varchar(100) not null,
  email varchar(100) not null
);

create table if not exists public.products (
  id serial primary key,
  name varchar(1000) not null,
  description varchar(1000),
  price money not null
);

create table if not exists public.receipts (
  id serial primary key,
  bag_id integer not null,
  purchase_date timestamp not null,
  customer_id integer not null,
  amount_to_pay money not null,

  foreign key (customer_id) references public.customers(id)
);

create table if not exists public.customer_receipts (
  id serial primary key,
  customer_id integer not null,
  receipt_id integer not null,

  foreign key (receipt_id) references public.receipts(id),
  foreign key (customer_id) references public.customers(id)
);

create table if not exists public.bags (
  id serial primary key,
  bag_id integer not null unique,
  product_id integer not null,

  foreign key (product_id) references public.products(id)
);

