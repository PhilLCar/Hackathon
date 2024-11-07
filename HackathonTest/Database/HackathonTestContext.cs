using System;
using System.Collections.Generic;
using HackathonTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackathonTest.Database;

public partial class HackathonTestContext : DbContext
{
    public HackathonTestContext(DbContextOptions<HackathonTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<FormField> FormFields { get; set; }

    public virtual DbSet<FormInput> FormInputs { get; set; }

    public virtual DbSet<FormSection> FormSections { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberField> MemberFields { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionField> TransactionFields { get; set; }

    public virtual DbSet<TransactionOwner> TransactionOwners { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fields_pkey");

            entity.HasIndex(e => e.Name, "fields_name_key").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('fields_id_seq'::regclass)");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(25);
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("forms_pkey");

            entity.HasIndex(e => e.Name, "forms_name_key").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('forms_id_seq'::regclass)");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(25);
        });

        modelBuilder.Entity<FormField>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("formfields_pkey");

            entity.HasIndex(e => new { e.Name, e.FormSectionId }, "FormFields_Name_FormSectionId_key").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('formfields_id_seq'::regclass)");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Field).WithMany(p => p.FormFields)
                .HasForeignKey(d => d.FieldId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("formfields_fieldid_fkey");

            entity.HasOne(d => d.FormSection).WithMany(p => p.FormFields)
                .HasForeignKey(d => d.FormSectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("formfields_roleid_fkey");
        });

        modelBuilder.Entity<FormInput>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("FormInputs_pkey");

            entity.Property(e => e.Name).HasMaxLength(25);

            entity.HasOne(d => d.FormSection).WithMany(p => p.FormInputs)
                .HasForeignKey(d => d.FormSectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FormInputs_FormSectionId_fkey");
        });

        modelBuilder.Entity<FormSection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('roles_id_seq'::regclass)");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Form).WithMany(p => p.FormSections)
                .HasForeignKey(d => d.FormId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Roles_FormId_fkey");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("members_pkey");

            entity.HasIndex(e => e.Email, "members_email_key").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('members_id_seq'::regclass)");
            entity.Property(e => e.Email).HasMaxLength(50);
        });

        modelBuilder.Entity<MemberField>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("memberfields_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('memberfields_id_seq'::regclass)");
            entity.Property(e => e.Value).HasMaxLength(100);

            entity.HasOne(d => d.Field).WithMany(p => p.MemberFields)
                .HasForeignKey(d => d.FieldId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("memberfields_fieldid_fkey");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberFields)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("memberfields_memberid_fkey");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transactions_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('transactions_id_seq'::regclass)");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.Done).HasDefaultValue(false);

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transactions_createdbyid_fkey");

            entity.HasOne(d => d.Form).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.FormId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transactions_formid_fkey");
        });

        modelBuilder.Entity<TransactionField>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transactionfields_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('transactionfields_id_seq'::regclass)");
            entity.Property(e => e.Value).HasMaxLength(100);

            entity.HasOne(d => d.FormField).WithMany(p => p.TransactionFields)
                .HasForeignKey(d => d.FormFieldId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transactionfields_formfieldid_fkey");

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionFields)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transactionfields_transactionid_fkey");
        });

        modelBuilder.Entity<TransactionOwner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transactionowners_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('transactionowners_id_seq'::regclass)");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.FormSection).WithMany(p => p.TransactionOwners)
                .HasForeignKey(d => d.FormSectionId)
                .HasConstraintName("transactionowners_ownasid_fkey");

            entity.HasOne(d => d.Owner).WithMany(p => p.TransactionOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("transactionowners_ownerid_fkey");

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionOwners)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transactionowners_transactionid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
