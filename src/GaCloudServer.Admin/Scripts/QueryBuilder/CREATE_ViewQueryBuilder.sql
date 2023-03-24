CREATE VIEW [dbo].[ViewQueryBuilderParamOnScripts]
AS
SELECT A.Id,A.Descrizione,A.QueryBuilderScriptId,A.Nome,B.Type ParamType,B.Descrizione ParamDesc,A.ApiUrl,A.Disabled
FROM QueryBuilderParamOnScripts A
LEFT JOIN QueryBuilderParamTypes B ON A.QueryBuilderParamTypeId= B.Id
GO

CREATE VIEW [dbo].[ViewQueryBuilderScripts]
AS
SELECT A.Id,A.Descrizione,B.Descrizione Section,A.Roles,A.SCript,A.Disabled
FROM QueryBuilderScripts A
LEFT JOIN QueryBuilderSections B ON A.QueryBuilderSectionId= B.Id
GO