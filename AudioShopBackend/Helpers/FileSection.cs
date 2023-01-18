using AudioShopBackend.Models;

namespace AudioShopBackend.Helpers
{
    public class FileSection
    {
        public enum AllFileTypes
        {
            CategoryPrimary = 1, CategorySidebar = 2, CategorySidebarBanner = 3, CategoryBanner = 4, CategorySlider = 5,
            ProductPrimary = 6, ProductSidebarBanner = 8, ProductBanner = 7, ProductSlider = 9,
            BlogPrimary = 10, BlogSidebar = 11, BlogSidebarBanner = 12, BlogBanner = 13, BlogSlider = 14, BlogContent = 15,
            Slider1 = 16, Slider2 = 17, Slider3 = 18, Slider4 = 19, Slider5 = 20,
            SmallBanner = 21, MediumBanner1 = 22, MediumBanner2 = 23, LargeBanner = 24,
            AboutUsLargeBanner = 25, AboutUsSocialBanner = 26, AboutUsBlogBanner = 27, AboutUsWhatWeDoBanner = 28, ShipPageBanner = 29
        }
        public enum FileTypeWidths
        {
            CategoryPrimary = 825, CategorySidebar = 270, CategorySidebarBanner = 300, CategoryBanner = 300, CategorySlider = 300,
            ProductPrimary = 600, ProductSidebarBanner = 300, ProductBanner = 300, ProductSlider = 300,
            BlogPrimary = 356, BlogSidebar = 300, BlogSidebarBanner = 300, BlogBanner = 825, BlogSlider = 300, BlogContent = 825,
            Slider1 = 825, Slider2 = 825, Slider3 = 825, Slider4 = 825, Slider5 = 825,
            SmallBanner = 300, MediumBanner1 = 550, MediumBanner2 = 550, LargeBanner = 1110,
            AboutUsLargeBanner = 1170, AboutUsSocialBanner = 370, AboutUsBlogBanner = 370, AboutUsWhatWeDoBanner = 370, ShipPageBanner = 1110
        }
        public enum FileTypeHeights
        {
            CategoryPrimary = 190, CategorySidebar = 345, CategorySidebarBanner = 300, CategoryBanner = 300, CategorySlider = 300,
            ProductPrimary = 600, ProductSidebarBanner = 300, ProductBanner = 300, ProductSlider = 300,
            BlogPrimary = 244, BlogSidebar = 300, BlogSidebarBanner = 300, BlogBanner = 567, BlogSlider = 300, BlogContent = 567,
            Slider1 = 520, Slider2 = 520, Slider3 = 520, Slider4 = 520, Slider5 = 520,
            SmallBanner = 300, MediumBanner1 = 221, MediumBanner2 = 221, LargeBanner = 400,
            AboutUsLargeBanner = 610, AboutUsSocialBanner = 255, AboutUsBlogBanner = 255, AboutUsWhatWeDoBanner = 255, ShipPageBanner = 763
        }
        public enum ProductFileTypes
        {
            primary = 6, sidebarBanner = 8, Banner = 7, Slider = 9
        }
        public enum CategoryFileTypes
        {
            primary = 1, sidebar = 2, sidebarBanner = 3, Banner = 4, Slider = 5
        }
        public enum BlogFileTypes
        {
            primary = 10, sidebar = 11, sidebarBanner = 12, Banner = 13, Slider = 14, Content = 15,
        }
        public enum CommonFileTypes
        {
            Slider1 = 16, Slider2 = 17, Slider3 = 18, Slider4 = 19, Slider5 = 20, 
            SmallBanner = 21,MediumBanner1 = 22, MediumBanner2 = 23, LargeBanner = 24, 
            AboutUsLargeBanner = 25, AboutUsSocialBanner = 26, AboutUsBlogBanner = 27, AboutUsWhatWeDoBanner = 28, ShipPageBanner = 29
        }
        public static IEnumerable<Models.File> GetFilesById(Guid NidRelate,byte RelateType) 
        {
            AudioShopDbContext audioShopDbContext = new AudioShopDbContext();
            return audioShopDbContext.Files.Where(p => p.RelateId == NidRelate && p.RelateType == RelateType).ToList();
        }
    }
}
