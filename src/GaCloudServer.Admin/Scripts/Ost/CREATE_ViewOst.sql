CREATE VIEW [dbo].[ViewOstTicket]
                AS
                SELECT * FROM OPENQUERY (OS_TICKET, 'SELECT 
    cdata.ticket_id,
	ticket.number,
	ticket.created as dateCreated,
	ticket.closed as dateClosed,
	ticket.lastupdate as dateLastUpdate,
    user.name as userOpen,
	user_email.address as userOpenEmail,
	staff.email as staff,
	topic.topic,
	cdata.subject,

	ticket.source,
	status.name,
	ticket.isanswered
FROM
    ost.ost_ticket AS ticket
        LEFT OUTER JOIN ost.ost_ticket__cdata AS cdata ON ticket.ticket_id = cdata.ticket_id
		LEFT OUTER JOIN ost.ost_ticket_status as status ON ticket.status_id=status.id
		LEFT OUTER JOIN ost.ost_user as user on ticket.user_id=user.id
		LEFT OUTER join ost.ost_staff as staff on ticket.staff_id=staff.staff_id
		LEFT OUTER JOIN ost.ost_user_email as user_email on ticket.user_id=user_email.user_id
		LEFT OUTER JOIN ost.ost_help_topic as topic ON ticket.topic_id=topic.topic_id')
GO


CREATE VIEW [dbo].[ViewOstTickets]
AS
SELECT        cast(dbo.ViewOstTicket.ticket_id as bigint) Id, cast(dbo.ViewOstTicket.ticket_id as int) ticket_id, dbo.ViewOstTicket.number, dbo.ViewOstTicket.dateCreated, dbo.ViewOstTicket.dateClosed, dbo.ViewOstTicket.dateLastUpdate, dbo.ViewOstTicket.userOpen, dbo.ViewOstTicket.userOpenEmail, 
                         dbo.ViewOstTicket.staff, dbo.ViewOstTicket.topic, dbo.ViewOstTicket.subject, dbo.ViewOstTicket.source, dbo.ViewOstTicket.name, CAST(dbo.ViewOstTicket.isanswered AS bit) as isanswered, CASE WHEN dbo.GlobalSettori.Descrizione IS NOT NULL THEN dbo.GlobalSettori.Descrizione else 'NON SPECIFICATO' END AS settore,CAST(0 as BIT) Disabled
FROM            dbo.ViewOstTicket LEFT OUTER JOIN
                         dbo.GlobalSettori INNER JOIN
                         dbo.GaPersonaleDipendenti ON dbo.GlobalSettori.Id = dbo.GaPersonaleDipendenti.GlobalSettoreId  INNER JOIN
                         AuthServerSSO.dbo.Users ON dbo.GaPersonaleDipendenti.UserId = AuthServerSSO.dbo.Users.Id ON dbo.ViewOstTicket.userOpenEmail = AuthServerSSO.dbo.Users.Email COLLATE database_default
GO