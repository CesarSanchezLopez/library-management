-- Create Database
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'LibraryDB')
BEGIN
    CREATE DATABASE LibraryDB;
END
GO