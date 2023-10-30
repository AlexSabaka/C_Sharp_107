create table public.students
(
  id serial primary key,
  name varchar(100) not null,
  birth_date date not null,
  final_project_id integer
);

create table public.projects
(
  id serial primary key,
  student_id integer not null,
  description varchar(1000),
  started_at date,
  finished_at date,
  github_url varchar(255),

  foreign key (student_id) references public.students(id)
);

alter table public.students add constraint students_project_fk foreign key (final_project_id) references public.projects(id);

insert into public.students (name, birth_date) values
  ('Oleksii Kruhlyk', '03/30/1994'),
  ('',);

insert into public.projects (student_id, description) values
  (1, '');

select * from public.students where ____ top 10 limit 10 