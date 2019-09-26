CREATE PROCEDURE ExcluirAmigo
(
	@Id int
)
as
begin 
	delete from Amigo where id = @id
end

Create Procedure AtualizarAmigo
(
	@id int,
	@Nome nvarchar(50),
	@Sobrenome nvarchar(50),
	@DataDeAniversario datetime
)

as begin
update Amigo set Nome = @Nome, Sobrenome = @Sobrenome, DataDeAniversario = @DataDeAniversario where Id = @id
end

Create Procedure InserirAmigo
(
	@Nome nvarchar(50),
	@Sobrenome nvarchar(50),
	@DataDeAniversario datetime
)
as
begin

insert into Amigo values(@Nome, @Sobrenome, @DataDeAniversario)

end

Create Procedure ListarAmigo

as
begin

	select Id, Nome, Sobrenome, DataDeAniversario from Amigo

end