CREATE TABLE employee(
code int primary key identity,
firstname varchar(20),
lastname varchar(20),
pesword varchar (20) unique not null
);


CREATE TABLE passwords (
code int primary key identity,
pesword varchar(20),
ExpiryDate date,
active bit, 
user1 INT FOREIGN KEY REFERENCES employee(code)
);



CREATE TABLE timeclock (
code int primary key identity,
Entrance datetime,
exits datetime,
user1 INT FOREIGN KEY REFERENCES employee(code)
);


SELECT * FROM timeclock
SELECT * FROM passwords
select * from employee

declare @pesword varchar (20) = '1234', @pesword2 varchar (20) = '12' ;

declare @firstname varchar (20) = '' , @lastname varchar(20) =  '', @code INT,  @answer varchar(200);


if exists (select * from employee where pesword = @pesword)
	begin
		SELECT @code = ( SELECT code from employee where pesword = @pesword)
	end
else
	begin 
     	 insert into employee values (@firstname,  @lastname,  @pesword)
		 select @code = @@IDENTITY
	end

 


IF exists (select * from Passwords WHERE user1=@code)
	begin
		if exists (select pesword From Passwords
					WHERE user1=@code AND pesword=@pesword2
					AND active=1 )
				begin
					if exists (select pesword From Passwords
					WHERE user1=@code AND pesword=@pesword2
					AND active=1 AND  ExpiryDate>=getdate())
						begin
							IF exists (SELECT * FROM timeclock
							WHERE user1=@code AND exits is null)
								begin 								
									UPDATE timeclock set exits=GETDATE()
									WHERE user1=@code AND exits is null;
									select @answer='Exit time: ' + CONVERT (NVARCHAR, GETDATE(), 121);
								end
							else
								begin
								INSERT INTO timeclock  VALUES (@code, GETDATE(), null);
								select @answer='Entry time: ' + CONVERT (NVARCHAR, GETDATE(), 121);
								end
						end
					ELSE
						begin
						select @answer= 'you need to update your password';
						end
				end
		ELSE
			begin
			select @answer = 'wrong password';
			end
	end
ELSE
	begin
		INSERT INTO	Passwords VALUES ( @pesword2,
		DATEADD(day, 180, GETDATE()),
		1,@code)
		select @answer= 'You created a worker and password';
	end

select @answer
