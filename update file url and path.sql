/****** Script for SelectTopNRows command from SSMS  ******/
declare @newpath nvarchar(3000) = 'c:\';
declare @newurl nvarchar(3000) = 'http://stereo9.ir/';
update Files set FilePath = CONCAT(@newpath , SUBSTRING(filepath,29,len(FilePath)- 28)),FileUrl = CONCAT(@newurl , SUBSTRING(FileUrl,23,len(FilePath)- 22))
  