

create table Funcionario
(
  CodFuncionario int identity(1,1) primary key,
  Nome varchar(400) not null,
  DataNascimento datetime not null,
  Salario numeric(18,2) not null,
  Atividades varchar(MAX) not null
)

select * from Funcionario
