IF NOT EXISTS (SELECT 1 FROM dbo.[User])
BEGIN
	-- fast way to check if there is any row
	INSERT INTO dbo.[User] (FirstName, LastName)
	VALUES 
		('John', 'Smith'),
		('David', 'Storm'),
		('Mary', 'Jones'),
		('Tim', 'Corey');
END