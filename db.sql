ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([NidProduct])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Products]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([NidUser])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Users]
GO
ALTER TABLE [dbo].[Brands]  WITH CHECK ADD  CONSTRAINT [FK_Brands_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([NidCategory])
GO
ALTER TABLE [dbo].[Brands] CHECK CONSTRAINT [FK_Brands_Categories]
GO
ALTER TABLE [dbo].[Types]  WITH CHECK ADD  CONSTRAINT [FK_Types_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([NidCategory])
GO
ALTER TABLE [dbo].[Types] CHECK CONSTRAINT [FK_Types_Categories]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([NidUser])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([NidProduct])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Products]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([NidUser])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Users]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Brands] FOREIGN KEY([RelateId])
REFERENCES [dbo].[Brands] ([NidBrand])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Brands]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Categories] FOREIGN KEY([RelateId])
REFERENCES [dbo].[Categories] ([NidCategory])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Categories]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Products] FOREIGN KEY([RelateId])
REFERENCES [dbo].[Products] ([NidProduct])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Products]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Types] FOREIGN KEY([RelateId])
REFERENCES [dbo].[Types] ([NidType])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Types]
GO
ALTER TABLE [dbo].[Links]  WITH CHECK ADD  CONSTRAINT [FK_Links_Products] FOREIGN KEY([RelateId])
REFERENCES [dbo].[Products] ([NidProduct])
GO
ALTER TABLE [dbo].[Links] CHECK CONSTRAINT [FK_Links_Products]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([NidOrder])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([NidProduct])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([NidUser])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([NidCategory])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([NidUser])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Users]
GO
ALTER TABLE [dbo].[Ships]  WITH CHECK ADD  CONSTRAINT [FK_Ships_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([NidOrder])
GO
ALTER TABLE [dbo].[Ships] CHECK CONSTRAINT [FK_Ships_Orders]
GO
USE [master]
GO
ALTER DATABASE [AudioShopDb] SET  READ_WRITE 
GO
