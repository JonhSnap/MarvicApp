using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Configurations
{
    class Notif_User_Configurations : IEntityTypeConfiguration<Notif_User>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Notif_User> builder)
        {
            builder.ToTable("Notif_User");


            // Data Seeding
            builder.HasData(
                new Notif_User()
                {
                    Id = new Guid("29D3D4E2-46AE-4257-9A95-FDE99546F53C"),
                    IdNotif = new Guid("3F5F79B2-27C2-45E1-842C-71811F9C8260"),
                    IdUser = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"),
                    IsView = EnumStatus.True
                },
                new Notif_User()
                {
                    Id = new Guid("565E5866-90F8-4960-B36B-F2D6F6C0D7F2"),
                    IdNotif = new Guid("20647F78-5EED-43BC-AC09-FCEBD546D2CE"),
                    IdUser = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("BEA2D6F1-B734-440F-900B-95A33F2CDEE3"),
                    IdNotif = new Guid("3F5F79B2-27C2-45E1-842C-71811F9C8260"),
                    IdUser = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"),
                    IsView = EnumStatus.True
                },
                new Notif_User()
                {
                    Id = new Guid("C67AAD9F-B67F-43B8-AA51-435BE6EEAE73"),
                    IdNotif = new Guid("20647F78-5EED-43BC-AC09-FCEBD546D2CE"),
                    IdUser = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("85505ECF-F765-43E7-BC5C-85BCCE8457A9"),
                    IdNotif = new Guid("3F5F79B2-27C2-45E1-842C-71811F9C8260"),
                    IdUser = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"),
                    IsView = EnumStatus.True
                },
                new Notif_User()
                {
                    Id = new Guid("1200DE61-ECCF-4389-91AC-613BA5CC1594"),
                    IdNotif = new Guid("20647F78-5EED-43BC-AC09-FCEBD546D2CE"),
                    IdUser = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"),
                    IsView = EnumStatus.False
                }///////////////////////////////
                ,
                new Notif_User()
                {
                    Id = new Guid("92d39770-8899-4244-a45d-00e67d268040"),
                    IdNotif = new Guid("60dde9a5-957c-4277-b811-981fc68491b0"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("ccb696e8-0dbd-414d-9401-01661ea5f795"),
                    IdNotif = new Guid("b5296929-cfe9-43a9-afce-4be240be62c7"),
                    IdUser = new Guid("d6c6033a-89e4-4217-b33b-95ee39ec4c5c"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("a6a5a774-f109-4889-85ac-07a6b0cda6ec"),
                    IdNotif = new Guid("bc5920aa-f292-4311-92b7-c28ecec2aef5"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("7a8ba24e-a434-4c77-93cc-08eecc910212"),
                    IdNotif = new Guid("bc5920aa-f292-4311-92b7-c28ecec2aef5"),
                    IdUser = new Guid("d6c6033a-89e4-4217-b33b-95ee39ec4c5c"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("8d6e8ee5-4f54-49dc-b844-099f42036b66"),
                    IdNotif = new Guid("189719e4-4de4-424f-a593-e691f313837f"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("2b0566b7-3874-449b-9686-0c4c070608eb"),
                    IdNotif = new Guid("b5398d9d-f910-4e6e-af3e-1ed6ca8f0ccf"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("a652f523-0550-4c11-aa02-11738fb160fa"),
                    IdNotif = new Guid("5e8a29d7-d221-46cf-8c75-1e87935647d5"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("3f95ef7a-4945-4992-b0c2-1364fadec7c4"),
                    IdNotif = new Guid("b5398d9d-f910-4e6e-af3e-1ed6ca8f0ccf"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("403a4999-53a7-46b6-a8d3-13a34a09eb97"),
                    IdNotif = new Guid("0ab0be60-f0d9-4071-980e-cab41b58258a"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("1a434355-0fbb-4131-82e3-1b96e3e83fce"),
                    IdNotif = new Guid("2b4ff5ae-7a4f-4401-ae47-2f822934986f"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("59774dbd-4708-4e82-b82f-285fbade0fcc"),
                    IdNotif = new Guid("67b654f1-faa8-4b49-b9d6-f2c81348b9fa"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("e85f0a4a-c5c9-4de9-b958-2adedada217f"),
                    IdNotif = new Guid("a0d1dda4-6161-41e2-91ef-3505c658c9b4"),
                    IdUser = new Guid("d6c6033a-89e4-4217-b33b-95ee39ec4c5c"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("3c9f7302-b904-404d-b531-2e87e46ef12f"),
                    IdNotif = new Guid("a0d1dda4-6161-41e2-91ef-3505c658c9b4"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("ae6a378e-20c0-4f81-a9dd-2ea89e1f0d2b"),
                    IdNotif = new Guid("60dde9a5-957c-4277-b811-981fc68491b0"),
                    IdUser = new Guid("d6c6033a-89e4-4217-b33b-95ee39ec4c5c"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("fa09f42b-11cb-4050-9b35-350892e2a9d1"),
                    IdNotif = new Guid("405feb09-8219-499a-903a-77e28dbb3127"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("b193e45b-6242-480e-9cd1-35700c05f3f8"),
                    IdNotif = new Guid("2b4ff5ae-7a4f-4401-ae47-2f822934986f"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("b4de14fa-e99f-4c6d-8c9a-37b5280a6508"),
                    IdNotif = new Guid("db813380-2c0f-4201-93a4-5483964c7bc1"),
                    IdUser = new Guid("346f2520-6295-4734-8868-6ca75258e7c1"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("a1781626-2880-464a-89a9-4054bf2fa3a3"),
                    IdNotif = new Guid("b5398d9d-f910-4e6e-af3e-1ed6ca8f0ccf"),
                    IdUser = new Guid("d6c6033a-89e4-4217-b33b-95ee39ec4c5c"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("90935f84-5744-4d59-b694-409751a22fdc"),
                    IdNotif = new Guid("b633f089-6a1b-4674-a965-bab9ccc51c23"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("c5448f11-3941-4785-9cd7-46c6c19ef3fb"),
                    IdNotif = new Guid("b5296929-cfe9-43a9-afce-4be240be62c7"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("14054b35-2499-42fe-924d-483361a86010"),
                    IdNotif = new Guid("b5398d9d-f910-4e6e-af3e-1ed6ca8f0ccf"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("7fb22a91-5de3-4e11-aa6a-483970693afc"),
                    IdNotif = new Guid("68c5de50-11f7-46e9-b805-af47012666d4"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("4f4f9eb9-9bef-494f-8197-487fb9804d6e"),
                    IdNotif = new Guid("3c8ade19-1a0d-4cbc-a54b-2ba7ea32eee2"),
                    IdUser = new Guid("d6c6033a-89e4-4217-b33b-95ee39ec4c5c"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("1258106b-b56c-4cf1-9583-4f5996edaf3a"),
                    IdNotif = new Guid("3c8ade19-1a0d-4cbc-a54b-2ba7ea32eee2"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("ecc2420b-4453-4076-85c7-52c8bb4ad51c"),
                    IdNotif = new Guid("60dde9a5-957c-4277-b811-981fc68491b0"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("edb1b4e5-7b3f-4322-b764-60055d419ad0"),
                    IdNotif = new Guid("03322409-4381-4b04-8f88-c9c51710bc1d"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("5e3ff395-925f-47dd-9f4b-63f58e78ba9f"),
                    IdNotif = new Guid("faae06e9-e155-4bb6-9134-c65ded0edfa8"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("ee7ef96c-a97a-48bc-9656-6e799a2190df"),
                    IdNotif = new Guid("3c8ade19-1a0d-4cbc-a54b-2ba7ea32eee2"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("e30876cb-40c8-4b27-aa43-754dd9ff6624"),
                    IdNotif = new Guid("189719e4-4de4-424f-a593-e691f313837f"),
                    IdUser = new Guid("d6c6033a-89e4-4217-b33b-95ee39ec4c5c"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("918b11ab-9fcd-4d1c-965e-7a7324678595"),
                    IdNotif = new Guid("5e8a29d7-d221-46cf-8c75-1e87935647d5"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("b34f1470-f042-495a-ae75-7f937eebf0f4"),
                    IdNotif = new Guid("bc5920aa-f292-4311-92b7-c28ecec2aef5"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("4a9f35e4-3472-4a1a-a7d1-8077fd7f6ca9"),
                    IdNotif = new Guid("0ab0be60-f0d9-4071-980e-cab41b58258a"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("b72ad9a8-a0b5-42c3-85b6-83ff8afe3a07"),
                    IdNotif = new Guid("83d841e4-d1f4-4af8-94b3-39acdff6469a"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("1498ac08-e8b6-4102-9238-84cc69eec93f"),
                    IdNotif = new Guid("60dde9a5-957c-4277-b811-981fc68491b0"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("8ddf6903-623f-495a-8abe-87fa6a7be128"),
                    IdNotif = new Guid("5e8a29d7-d221-46cf-8c75-1e87935647d5"),
                    IdUser = new Guid("d6c6033a-89e4-4217-b33b-95ee39ec4c5c"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("1a17260e-574e-407b-b8e4-8c2cc5a51053"),
                    IdNotif = new Guid("f3dcd856-3e68-47e7-bc6a-50b836eddec0"),
                    IdUser = new Guid("346f2520-6295-4734-8868-6ca75258e7c1"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("071a63ec-d131-4928-8d15-8d0bdac5854b"),
                    IdNotif = new Guid("68c5de50-11f7-46e9-b805-af47012666d4"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("f0b21e19-1668-45d9-86e2-9138fb92e08e"),
                    IdNotif = new Guid("03322409-4381-4b04-8f88-c9c51710bc1d"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("15c3d016-5cc5-4bd3-8dc0-93965147d846"),
                    IdNotif = new Guid("0ab0be60-f0d9-4071-980e-cab41b58258a"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("f2fcce7c-f844-4520-abc2-9c4cbe08e258"),
                    IdNotif = new Guid("67b654f1-faa8-4b49-b9d6-f2c81348b9fa"),
                    IdUser = new Guid("346f2520-6295-4734-8868-6ca75258e7c1"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("425140c7-a8d3-4e97-9d7c-a324e231c0a9"),
                    IdNotif = new Guid("fbaf016c-dcac-4cb4-be6f-c74a3859dcef"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("de48eab5-c8bd-4a0f-bede-a6ef4d4b6578"),
                    IdNotif = new Guid("fbaf016c-dcac-4cb4-be6f-c74a3859dcef"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("a470bbd4-d749-44dc-8770-a78e0c52c75d"),
                    IdNotif = new Guid("4d6c13e9-e387-4e4d-9ab0-253515d785f9"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("158f918d-cec7-4b98-90e1-a94e87468897"),
                    IdNotif = new Guid("faae06e9-e155-4bb6-9134-c65ded0edfa8"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("4270afa2-a980-4d52-af0e-a960d222a2fa"),
                    IdNotif = new Guid("b5296929-cfe9-43a9-afce-4be240be62c7"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("17c4a08b-e007-441f-953d-ab12967a95ad"),
                    IdNotif = new Guid("db813380-2c0f-4201-93a4-5483964c7bc1"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("77139bac-889a-4d5a-b684-abecd9cb8db3"),
                    IdNotif = new Guid("189719e4-4de4-424f-a593-e691f313837f"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("30e1e270-50dc-45ed-9912-c1b68d61ea81"),
                    IdNotif = new Guid("3c8ade19-1a0d-4cbc-a54b-2ba7ea32eee2"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("06fefd05-d616-41a0-a9cb-d684fa514d30"),
                    IdNotif = new Guid("f3dcd856-3e68-47e7-bc6a-50b836eddec0"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("c3e83c68-700d-48a8-a2a3-d75433cba974"),
                    IdNotif = new Guid("a0d1dda4-6161-41e2-91ef-3505c658c9b4"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("2c3d014b-7dba-4974-a56b-d9adc3352fab"),
                    IdNotif = new Guid("fbaf016c-dcac-4cb4-be6f-c74a3859dcef"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("435d6809-aa2f-474f-97bb-da0b29e25597"),
                    IdNotif = new Guid("bc5920aa-f292-4311-92b7-c28ecec2aef5"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("0727238b-5e68-42ba-904a-da60fcca8ef4"),
                    IdNotif = new Guid("2b4ff5ae-7a4f-4401-ae47-2f822934986f"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("5419c96c-a767-456c-b8e2-dcd5855a157d"),
                    IdNotif = new Guid("b5296929-cfe9-43a9-afce-4be240be62c7"),
                    IdUser = new Guid("71fbd467-6496-412c-b6fa-b461cab6dd05"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("06cc884a-54ae-4c9b-9423-df8ab11d14ab"),
                    IdNotif = new Guid("03322409-4381-4b04-8f88-c9c51710bc1d"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("f1a6b128-db47-4407-a5da-df8fe8a879a4"),
                    IdNotif = new Guid("03322409-4381-4b04-8f88-c9c51710bc1d"),
                    IdUser = new Guid("d6c6033a-89e4-4217-b33b-95ee39ec4c5c"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("4376bf5d-6b7a-400b-84ff-e0039d29f65e"),
                    IdNotif = new Guid("45a5903e-08b9-4495-9e78-2266f6b48ac0"),
                    IdUser = new Guid("346f2520-6295-4734-8868-6ca75258e7c1"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("43238979-e021-417e-a07f-e14a7dd45844"),
                    IdNotif = new Guid("189719e4-4de4-424f-a593-e691f313837f"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("12a38745-7a5b-41bc-9aac-e29e0661dc01"),
                    IdNotif = new Guid("a0d1dda4-6161-41e2-91ef-3505c658c9b4"),
                    IdUser = new Guid("3413ed48-771a-4533-91b0-8c19cd863e2f"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("b7b2353d-8caa-454f-8d9e-ef1ee3d0b223"),
                    IdNotif = new Guid("2b4ff5ae-7a4f-4401-ae47-2f822934986f"),
                    IdUser = new Guid("d6c6033a-89e4-4217-b33b-95ee39ec4c5c"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("5d7dfb24-ae13-4180-a645-fa655f43e2ed"),
                    IdNotif = new Guid("0ab0be60-f0d9-4071-980e-cab41b58258a"),
                    IdUser = new Guid("d6c6033a-89e4-4217-b33b-95ee39ec4c5c"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("900d8dd8-9d5a-45ec-9187-fdd4fe66186f"),
                    IdNotif = new Guid("5e8a29d7-d221-46cf-8c75-1e87935647d5"),
                    IdUser = new Guid("a21973b7-eb51-4141-a7f8-be3e9071bf9a"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("eeba447b-117e-4fb9-a5a7-fdf092f9ea86"),
                    IdNotif = new Guid("fbaf016c-dcac-4cb4-be6f-c74a3859dcef"),
                    IdUser = new Guid("d6c6033a-89e4-4217-b33b-95ee39ec4c5c"),
                    IsView = EnumStatus.True
                }
                );
        }
    }
}
