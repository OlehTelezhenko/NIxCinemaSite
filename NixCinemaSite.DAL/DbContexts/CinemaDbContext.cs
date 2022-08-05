using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NixCinemaSite.DAL.Entities;
using NixCinemaSite.DAL.Entities.Identity;

//сертификаты
//https://www.google.com/search?q=age+classification+movies&tbm=isch&chips=q:age+classification+movies,online_chips:certificate+ratings:Blgtu2nYnt8%3D&hl=ru&sa=X&ved=2ahUKEwigvoDjqO_4AhXhsIsKHbbYDzMQ4lYoBHoECAEQKA&biw=1423&bih=757
//https://www.bbfc.co.uk/about-classification/classification-guidelines

//Add-Migration Migrationkek -Project NixCinemaSite.DAL
//update-database -Project NixCinemaSite.DAL

namespace NixCinemaSite.DAL.DbContexts
{
    public class CinemaDbContext : IdentityDbContext<User>
    {
        // TODO nubble reference dbcontext https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types#dbcontext-and-dbset
        public DbSet<CertificateEntity>? Certificates { get; set; }
        public DbSet<CountryEntity>? Countries { get; set; }
        public DbSet<FilmEntity>? Films { get; set; }
        public DbSet<GenreEntity>? Genres { get; set; }
        public DbSet<MediaEntity>? Medias { get; set; }
        public DbSet<PersonEntity>? Persons { get; set; }
        public DbSet<FilmToPersonEntity>? FilmToPeople { get; set; }

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FilmToPersonEntity>()
                .HasKey(bc => new { bc.FilmId, bc.PersonId });
            modelBuilder.Entity<FilmToPersonEntity>()
                .HasOne(bc => bc.Film)
                .WithMany(b => b.FilmsToPersons)
                .HasForeignKey(bc => bc.FilmId);
            modelBuilder.Entity<FilmToPersonEntity>()
                .HasOne(bc => bc.Person)
                .WithMany(c => c.FilmsToPersons)
                .HasForeignKey(bc => bc.PersonId);

            modelBuilder.Entity<CertificateEntity>().HasData(new CertificateEntity[]
    {
                    new CertificateEntity(){
                        Id = Guid.NewGuid(),
                        Name = "U Universal - Suitable for all",
                        Description = "U films should be set within a positive framework and should offer reassuring counterbalances to any violence, threat or horror. If a work is particularly suitable for pre-school children, this will be indicated in the Ratings Info.",
                        Image ="Url"
                    },
                     new CertificateEntity(){
                        Id = Guid.NewGuid(),
                        Name = "PG Parental Guidance",
                        Description = "General viewing, but some scenes may be unsuitable for young children. A PG film should not unsettle a child aged around eight or older. Unaccompanied children of any age may watch, but parents are advised to consider whether the content may upset younger, or more sensitive, children.",
                        Image ="Url"
                    },
                     new CertificateEntity(){
                        Id = Guid.NewGuid(),
                        Name = "12A/12 – Suitable for 12 years and over",
                        Description = "Films classified 12A and video works classified 12 contain material that is not generally suitable for children aged under 12. No one younger than 12 may see a 12A film in a cinema unless accompanied by an adult. Adults planning to take a child under 12 to view a 12A film should consider whether the film is suitable for that child. To help them decide, we recommend that they check the Ratings Info for that film in advance. No one younger than 12 may rent or buy a 12 rated video work.",
                        Image ="Url"
                    },
                     new CertificateEntity(){
                        Id = Guid.NewGuid(),
                        Name = "15 – Suitable only for 15 years and over",
                        Description= "No one younger than 15 may see a 15 film in a cinema. No one younger than 15 may rent or buy a 15 rated video work.",
                        Image ="Url"
                    },
                     new CertificateEntity(){
                        Id = Guid.NewGuid(),
                        Name = "18 – Suitable only for adults",
                        Description ="No one younger than 18 may see an 18 film in a cinema. No one younger than 18 may rent or buy an 18 rated video work. Adults should be free to choose their own entertainment.",
                        Image ="Url"
                    },
                     new CertificateEntity(){
                        Id = Guid.NewGuid(),
                        Name = "R18 - To be shown only in specially licensed cinemas",
                        Description ="The R18 category is a special and legally-restricted classification primarily for explicit works of consenting sex or strong fetish material involving adults. Films may only be shown to adults in specially licensed cinemas, and video works may be supplied to adults only in licensed sex shops. R18 video works may not be supplied by mail order.",
                        Image ="Url"
                    },
    });
            modelBuilder.Entity<CountryEntity>().HasData(new CountryEntity[]
                {
                    new CountryEntity(){ Name = "Австралія", Id = Guid.NewGuid() },
                    new CountryEntity(){ Name = "Австрія", Id = Guid.NewGuid() },
                    new CountryEntity(){ Name = "Бельгія", Id = Guid.NewGuid() },
                    new CountryEntity(){ Name = "Болгарія", Id = Guid.NewGuid() },
                    new CountryEntity(){ Name = "Бразилія", Id = Guid.NewGuid() },
                    new CountryEntity(){ Name = "Греція", Id = Guid.NewGuid() },
                    new CountryEntity(){ Name = "Грузія", Id = Guid.NewGuid() },
                });
            modelBuilder.Entity<GenreEntity>().HasData(new GenreEntity[]
    {
                    new GenreEntity(){ Name = "Комедія", Id = Guid.NewGuid() },
                    new GenreEntity(){ Name = "Фантастика", Id = Guid.NewGuid() },
                    new GenreEntity(){ Name = "Жахи", Id = Guid.NewGuid() },
                    new GenreEntity(){ Name = "Бойовик", Id = Guid.NewGuid() },
                    new GenreEntity(){ Name = "Мелодрами", Id = Guid.NewGuid() },
                    new GenreEntity(){ Name = "Містика", Id = Guid.NewGuid() },
                    new GenreEntity(){ Name = "Детектив", Id = Guid.NewGuid() },
    });
            modelBuilder.Entity<PersonEntity>().HasData(new PersonEntity[]
                {
                    new PersonEntity(){
                        Id = Guid.NewGuid(),
                        FirstName = "Роберт",  
                        LastName = "Дауні мол.",
                        DateOfBirth = DateTime.Parse("04.04.1965"),
                        Bio = "Роберт Дауні-молодший народився в Манхеттені, Нью-Йорк, молодший з двох дітей. Його батько — Роберт Дауні-старший — режисер, актор і продюсер, а його мати, Елсі (у дівоцтві Форд) — теж актриса. У батька Дауні — ірландське та російсько-єврейське походження, а у матері — німецьке та шотландське походження. Його батько народився з ім'ям Роберт Еліас, але змінив своє прізвище на Дауні (як у його вітчима Джеймса Дауні), коли він був неповнолітнім і хотів вступити на службу в армію.У Дауні були невеликі ролі в проектах свого батька в дитинстві. Він дебютував в кіно у віці п'яти років і грав хворого цуценя у фільмі \"Загін\" (1970), потім у віці семи років знявся в \"Палаці Грисера\" (1972). У віці 10 років, він жив в Англії і вивчав класичний балет, як частина більш великої програми. Він виріс в Грінвіч-Виллидже і навчався в навчальному центрі виконавських мистецтв \"Stagedoor Manor\" в північній частині штату Нью-Йорк, коли був підлітком. Коли його батьки розлучилися в 1978 році, Дауні переїхав до Каліфорнії зі своїм батьком, але в 1982 році він покинув середню школу Санта-Моніки і переїхав в Нью-Йорк, щоб продовжити акторську кар'єру..",
                        Photo = "Url"
                    },
                    new PersonEntity(){
                        Id = Guid.NewGuid(),
                        FirstName = "Анджеліна ",
                        LastName = "Джолі",
                        DateOfBirth = DateTime.Parse("04.06.1975"),
                        Bio = "Анджеліна Джолі Войт народилася 4 червня 1975 року в Лос-Анджелесі, штат Каліфорнія. Її батько - актор Йон Войт, був до того часу номінантом на премію \"Оскар\" за роль в фільмі \"Опівнічний ковбой\" Джона Шлезінгера і отримав її в 1978 році. Мати Анджеліни - також актриса, хоча і менш заслужена - Марселін Бертран. Батьки розійшлися, коли дівчинці було всього рік, але продовжували тим не менш разом займатися її вихованням. За своїм походженням Анджеліна Джолі набула кров кількох народів: німецьку, словацьку, голландську, франко-канадський і ирокезскую (по материнській лінії). Французькою мовою прізвище Джолі означає «красива». На її животі красується татуювання на латині \"Quod me nutrit me destruit\", яка перекладається \"Що живить мене, то й руйнує\". Серед інших татуювань на тілі актриси є японський символ смерті, дракон і великий чорний хрест на животі.",
                        Photo = "Url"
                    },
                    new PersonEntity(){
                        Id = Guid.NewGuid(),
                        FirstName = "Володимир",
                        LastName = "Зеленський",
                        DateOfBirth = DateTime.Parse("25.1.1978"),
                        Bio = "Владимир Александрович Зеленский родился 25 января 1978 года в городе Кривой Рог (Украинская ССР) в украинско-еврейской семье\"\". Владеет украинским, русским и английским языками\". Дед — Семён Иванович Зеленский (1924, Кривой Рог — ?), украинец\", участник Великой Отечественной войны. В годы войны — командир миномётного взвода, затем — командир стрелковой роты 174-го гвардейского стрелкового полка 57-й гвардейской стрелковой дивизии. В 1944 году награждён двумя орденами Красной Звезды, войну закончил в звании гвардии лейтенанта\"\"\". Отец — Александр Семёнович Зеленский (род. 23 декабря 1947), математик, программист\", доктор технических наук, профессор, заведующий кафедрой информатики — преподаватель в том же вузе, где учился Владимир\"\". Отец 20 лет жил и работал в Монголии, строил горно-обогатительный комбинат в городе Эрдэнэт\". Мать — Римма Владимировна Зеленская (род. 16 сентября 1950), имеет инженерное образование, трудовой стаж 40 лет, в настоящее время на пенсии\". В детстве прожил с родителями четыре года в Монголии, где работал отец. Окончил там первый класс, после чего Владимир с матерью вернулись в Кривой Рог\". Учился в школе № 95 с углублённым изучением английского языка. В школьные годы занимался греко-римской борьбой\", тяжёлой атлетикой, собирал марки, играл на пианино, занимался бальными танцами, играл в баскетбол и волейбол. Принимал участие в школьной самодеятельности, был гитаристом в школьном ансамбле\". В 16 лет получил грант на бесплатное обучение в Израиле, но отец был против этого\". Окончил школу в 1995 году. В школе мечтал стать дипломатом и даже готовился поступать в МГИМО, но поступил на обучение по специальности \"Правоведение\" в Криворожский экономический институт Киевского национального экономического университета, который окончил в 2000 году. По полученной специальности никогда не работал.",
                        Photo = "Url"
                    },
                });
        }
    }
}
