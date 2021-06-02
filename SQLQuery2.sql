Create Trigger TriggerCentrala on Centrale 
instead of insert 
as begin 
declare @naziv varchar(50);
select @naziv = i.Naziv from inserted i;
insert into Centrale(Naziv) values (@naziv);
print 'Trigger for Centrale is called';
end

insert into Centrale(Naziv) values ('nekidrugi');