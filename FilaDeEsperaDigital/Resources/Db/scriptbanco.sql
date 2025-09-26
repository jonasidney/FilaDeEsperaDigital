
create table pessoa(

  id uuid references auth.users on update cascade on delete cascade,
  nome varchar(80),
  sobrenome_atividade varchar(80),
  telefone varchar(11),
  endereco varchar(150),
  primary key (id)  

);

alter table pessoa enable row level security;
create policy "Cada usuário insere apenas os seus dados" on pessoa
for insert
to authenticated
WITH CHECK (auth.uid() = id);

create policy "Cada usuário altera apenas os seus dados" on pessoa
for update
to authenticated
using (auth.uid() = id)
WITH CHECK (auth.uid() = id);

create policy "Cada usuário deleta apenas os seus dados" on pessoa
for delete
to authenticated
using (auth.uid() = id);

create policy "Cada usuário seleciona o seu cadastro e dos estabelecimentos" on pessoa
for select
to authenticated
using (auth.uid() = id or perfil = 'p');

//p = Prestador | c = Consumidor


alter table pessoa add column perfil varchar(1);

create table fila(

 id uuid primary key default gen_random_uuid(),
 id_estabelecimento uuid references pessoa(id),
 id_cliente uuid references pessoa(id),
 data_hora_entrada timestamp default current_timestamp,
 data_hora_inicio timestamp,
 data_hora_fim timestamp

);

alter table fila enable row level security;
create policy "Cada usuário edita sua própria fila" on fila to authenticated using ( (select auth.uid()) in (id_estabelecimento, id_cliente));




