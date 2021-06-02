Create Trigger TriggerKompanija on Kompanije 
instead of insert 
as begin 
declare @naziv varchar(50);
select @naziv = i.Naziv from inserted i;
insert into Kompanije(Naziv) values (@naziv);
print 'Trigger for Kompanija is called';
end

