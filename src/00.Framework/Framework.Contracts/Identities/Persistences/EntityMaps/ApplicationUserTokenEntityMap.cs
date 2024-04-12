﻿namespace Framework.Contracts.Identities.Persistences.EntityMaps;

public class
    ApplicationUserTokenEntityMap : IEntityTypeConfiguration<
        ApplicationUserToken>
{
    public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
    {
        builder.ToTable("ApplicationUserTokens");
    }
}