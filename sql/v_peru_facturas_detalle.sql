USE [BDQualityv]
GO

/****** Object:  View [dbo].[v_peru_facturas_detalle]    Script Date: 07/01/2018 21:49:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter VIEW [dbo].[v_peru_facturas_detalle]
AS
SELECT     '1' as tipo_comprobante,
           fd.tipoDocumento as tipo,
            dbo.FUN_PUNTO(fd.tipoDocumento) as serie,
           fd.numero as numero,
           fd.codigo_principal,
           fd.Descripcion, 
           CAST(ROUND(fd.Cantidad, 2) AS decimal(18, 2)) AS CANTIDAD,
           CAST(ROUND(fd.Precio_Uni, 2) AS decimal(18,2)) AS VALOR_UNITARIO,
           CAST(ROUND(fd.Precio_Uni*1.18, 2) AS decimal(18,2)) AS PRECIO_UNITARIO,
           CAST(ROUND(fd.Cantidad * (fd.Precio_Uni-fd.Descuento), 2) AS decimal(18, 2)) AS SUBTOTAL,
           CAST(ROUND((fd.Cantidad*fd.Precio_Uni*0.18),2)AS decimal(18,2)) AS IGV_LINEA,
           CAST(ROUND((fd.Cantidad*fd.Precio_Uni*1.18),2)AS decimal(18,2)) AS TOTAL_LINEA
  FROM         dbo.fe_facturadetalle fd

GO


