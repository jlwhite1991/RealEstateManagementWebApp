BEGIN TRANSACTION;

CREATE TABLE unit (
	unit_id integer NOT NULL IDENTITY(1,1),
	property_id integer NOT NULL,
	tenant_id integer NULL,
	monthly_rent numeric(8, 2) NOT NULL,
	square_feet integer NOT NULL,
	number_of_beds integer NOT NULL,
	number_of_baths float NOT NULL,
	description nvarchar(max) NULL,
	tagline nvarchar(280) NULL,
	image_source nvarchar(max) NULL,
	application_fee numeric(8, 2) NOT NULL,
	security_deposit numeric(8, 2) NOT NULL,
	pet_deposit numeric(8, 2) NOT NULL,
	address_line_1 nvarchar(200) NOT NULL,
	address_line_2 nvarchar(200) NULL,
	city nvarchar(200) NOT NULL,
	us_state nvarchar(50) NOT NULL,
	zip_code integer NOT NULL,
	washer_dryer bit NULL,
	allow_cats bit NULL,
	allow_dogs bit NULL,
	parking_spots nvarchar(50) NULL,
	gym bit NULL,
	pool bit NULL,
	CONSTRAINT pk_unit_id PRIMARY KEY (unit_id),
);

CREATE TABLE property (
	property_id integer NOT NULL IDENTITY(1,1),
	owner_id integer NOT NULL,
	manager_id integer NOT NULL,
	property_name nvarchar(max) NOT NULL,
	property_type nvarchar(50) NOT NULL,
	number_of_units integer NOT NULL,
	image_source nvarchar(max) NULL,
	CONSTRAINT pk_property_id PRIMARY KEY (property_id),
);

CREATE TABLE site_user (
	user_id integer NOT NULL IDENTITY(1,1),
	first_name nvarchar(50) NOT NULL,
	last_name nvarchar(50) NOT NULL,
	phone_number nvarchar(50) NOT NULL,
	email_address nvarchar(50) NOT NULL,
	role nvarchar(50) NOT NULL,
	password nvarchar(50) NOT NULL,
	salt nvarchar(50) NOT NULL,
	CONSTRAINT pk_user_id PRIMARY KEY (user_id),
);

CREATE TABLE service_request (
	request_id integer NOT NULL IDENTITY(1,1),
	tenant_id integer NOT NULL,
	description nvarchar(max) NULL,
	is_emergency bit NULL,
	category nvarchar(50) NULL,
	is_completed bit NULL,
	CONSTRAINT pk_request_id PRIMARY KEY (request_id),
);

CREATE TABLE tenant_application (
	application_id integer NOT NULL IDENTITY(1,1),
	unit_id integer, 
	first_name nvarchar(50) NOT NULL,
	last_name nvarchar(50) NOT NULL,
	social_security_number integer NULL,
	phone_number nvarchar(50) NOT NULL,
	email_address nvarchar(50) NOT NULL,
	last_residence_owner nvarchar(50) NULL,
	last_residence_contact_phone_number nvarchar(50) NULL,
	last_residence_tenancy_start_date nvarchar(50) NULL,
	last_residence_tenancy_end_date nvarchar(50) NULL,
	employment_status bit NULL,
	employer_name nvarchar(50) NULL,
	employer_contact_phone_number nvarchar(50) NULL,
	annual_income nvarchar(50) NULL,
	number_of_residents integer NOT NULL,
	number_of_cats integer NULL,
	number_of_dogs integer NULL,
	application_approval_status bit NULL DEFAULT NULL,
	CONSTRAINT pk_application_id PRIMARY KEY (application_id),
);

CREATE TABLE payment (
	payment_id integer NOT NULL IDENTITY(1,1),
	unit_id integer NOT NULL,
	tenant_id integer NOT NULL,
	payment_amount DECIMAL(13,2) NOT NULL,
	CONSTRAINT pk_payment_id PRIMARY KEY (payment_id),
);


SET IDENTITY_INSERT unit ON;


INSERT INTO unit (unit_id, property_id, tenant_id, monthly_rent, square_feet, number_of_beds, number_of_baths, description, tagline, image_source, application_fee, security_deposit, pet_deposit, address_line_1, city, us_state, zip_code, washer_dryer, allow_cats, allow_dogs, parking_spots, gym, pool) VALUES (1, 1, 3, 900, 1000, 1, 1, 'By the river but not beneath the river!', 'Not underwater!', 'https://upload.wikimedia.org/wikipedia/commons/thumb/d/dc/SR_315_Olentangy_bridge_2018.jpg/1200px-SR_315_Olentangy_bridge_2018.jpg', 45, 450, 200, '200 Dryshore Lane', 'Columbus', 'Ohio', 43210, 0, 0, 0, 'Street Parking', 0, 1);

INSERT INTO unit (unit_id, property_id, monthly_rent, square_feet, number_of_beds, number_of_baths, description, tagline, image_source, application_fee, security_deposit, pet_deposit, address_line_1, city, us_state, zip_code, washer_dryer, allow_cats, allow_dogs, parking_spots, gym, pool) VALUES (2, 1, 1200, 1300, 2, 1.5, 'Stylish, nautical-themed abode - comes fully furnished!', 'Riverside paradise!', 'https://upload.wikimedia.org/wikipedia/en/d/d3/Olentangy_River.jpg', 45, 600, 200, '221 Dryshore Lane', 'Columbus', 'Ohio', 43210, 1, 1, 1, '1 Car Garage', 0, 1);

INSERT INTO unit (unit_id, property_id, tenant_id, monthly_rent, square_feet, number_of_beds, number_of_baths, description, tagline, image_source, application_fee, security_deposit, pet_deposit, address_line_1, city, us_state, zip_code, washer_dryer, allow_cats, allow_dogs, parking_spots, gym, pool) VALUES (3, 2, 4, 7000, 10000, 4, 5, 'The finest money can buy or else your money back*!', 'Pay me or leave.', 'https://upload.wikimedia.org/wikipedia/commons/6/6a/Neoeclectichomes.JPG', 2500, 10000, 1000, '1 Snooty Boulevard', 'Columbus', 'Ohio', 43206, 1, 1, 1, '5 Car Garage', 1, 1);

INSERT INTO unit (unit_id, property_id, tenant_id, monthly_rent, square_feet, number_of_beds, number_of_baths, description, tagline, image_source, application_fee, security_deposit, pet_deposit, address_line_1, city, us_state, zip_code, washer_dryer, allow_cats, allow_dogs, parking_spots, gym, pool) VALUES (4, 3, 5, 750, 1400, 2, 2.5, 'The finest loft available!', 'Fresh!', 'https://upload.wikimedia.org/wikipedia/commons/6/62/Burger_King%2C_Saugus.jpg', 0, 300, 100, '67 King Row', 'Columbus', 'Ohio', 43219, 0, 1, 0, 'Street Parking', 1, 0);

INSERT INTO unit (unit_id, property_id, monthly_rent, square_feet, number_of_beds, number_of_baths, description, tagline, image_source, application_fee, security_deposit, pet_deposit, address_line_1, city, us_state, zip_code, washer_dryer, allow_cats, allow_dogs, parking_spots, gym, pool) VALUES (5, 3, 850, 1500, 2, 2.5, 'Probably not a restaurant', 'Smells like french fries!', 'http://media.zenfs.com/en-US/homerun/investorplace_417/02332c1f6f09e8412498d3fecd939cd4', 0, 400, 120, '68 King Row', 'Columbus', 'Ohio', 43219, 1, 1, 1, 'Street Parking', 1, 1);

INSERT INTO unit (unit_id, property_id, monthly_rent, square_feet, number_of_beds, number_of_baths, description, tagline, image_source, application_fee, security_deposit, pet_deposit, address_line_1, city, us_state, zip_code, washer_dryer, allow_cats, allow_dogs, parking_spots, gym, pool) VALUES (6, 3, 950, 1600, 3, 2.5, 'Do you love burgers? I know I love them.', 'Minimum wage is okay!', 'http://ccsconstructionservice.com/wp-content/uploads/2015/04/Grandview-BK-8-Web.jpg', 0, 500, 140, '69 King Row', 'Columbus', 'Ohio', 43219, 1, 1, 1, '1 Car Garage', 1, 1);


SET IDENTITY_INSERT unit OFF;


SET IDENTITY_INSERT property ON;


INSERT INTO property (property_id, owner_id, manager_id, property_name, property_type, number_of_units, image_source) VALUES (1, 2, 1, 'Aquamarine Paradise', 'Duplex', 2, 'https://library.osu.edu/blogs/archives/files/2012/09/01_2013_olentangy_river.jpg');

INSERT INTO property (property_id, owner_id, manager_id, property_name, property_type, number_of_units, image_source) VALUES (2, 2, 1, 'McMansion', 'Single Family', 1, 'https://upload.wikimedia.org/wikipedia/commons/6/63/Bulcolic_Mc_Mansions_Leesburg_%284949100182%29.jpg');

INSERT INTO property (property_id, owner_id, manager_id, property_name, property_type, number_of_units, image_source) VALUES (3, 2, 1, 'Kingly Estates', 'Triplex', 3, 'https://lighting.cree.com/media/resized/casestudy/images/Cree_Restaurant_BurgerKing_SavoyIL_CaseStudy_004w=625h=400.jpg');


SET IDENTITY_INSERT property OFF;


SET IDENTITY_INSERT site_user ON;


INSERT INTO site_user (user_id, first_name, last_name, phone_number, email_address, role, password, salt) VALUES (1, 'Jason', 'Todd', '555-555-5555', 'jason@donotbotherme.com', 'manager', 'password', 'salt');

INSERT INTO site_user (user_id, first_name, last_name, phone_number, email_address, role, password, salt) VALUES (2, 'Dick', 'Grayson', '666-666-6666', 'dick@donotbotherme.com', 'owner', 'password', 'salt');

INSERT INTO site_user (user_id, first_name, last_name, phone_number, email_address, role, password, salt) VALUES (3, 'Damian', 'Wayne', '777-777-7777', 'damian@donotbotherme.com', 'tenant', 'password', 'salt');

INSERT INTO site_user (user_id, first_name, last_name, phone_number, email_address, role, password, salt) VALUES (4, 'Tim', 'Drake', '888-888-8888', 'tim@donotbotherme.com', 'tenant', 'password', 'salt');

INSERT INTO site_user (user_id, first_name, last_name, phone_number, email_address, role, password, salt) VALUES (5, 'Stephanie', 'Brown', '999-999-9999', 'stephanie@donotbotherme.com', 'tenant', 'password', 'salt');


SET IDENTITY_INSERT site_user OFF;


SET IDENTITY_INSERT service_request ON;


INSERT INTO service_request (request_id, tenant_id, description, is_emergency, category, is_completed) VALUES (1, 3, 'There is a hole in my ceiling and I definitely did not cause it.', 1, 'property damage', 0);

INSERT INTO service_request (request_id, tenant_id, description, is_emergency, category, is_completed) VALUES (2, 4, 'Water leak in my bathroom.', 0, 'plumbing', 1);

INSERT INTO service_request (request_id, tenant_id, description, is_emergency, category) VALUES (3, 5, 'My power is out and there is a lot of static electricity everywhere.', 1, 'electrical');


SET IDENTITY_INSERT service_request OFF;


SET IDENTITY_INSERT tenant_application ON;


INSERT INTO tenant_application (application_id, unit_id, first_name, last_name, phone_number, email_address, last_residence_owner, last_residence_contact_phone_number, last_residence_tenancy_start_date, last_residence_tenancy_end_date, employment_status, employer_name, employer_contact_phone_number, annual_income, number_of_residents, number_of_cats, number_of_dogs, application_approval_status) VALUES (1, 2, 'Bruce', 'Wayne', '426-228-6261', 'bruce@wayneenterprises.com', 'Thomas Wayne', '555-426-3323', 'March 30, 1939', 'April 10, 2019', 0, 'Self-Employed', 'NA', '1000000000', 2, 0, 0, 0);

INSERT INTO tenant_application (application_id, unit_id, first_name, last_name, phone_number, email_address, last_residence_owner, last_residence_contact_phone_number, last_residence_tenancy_start_date, last_residence_tenancy_end_date, employment_status, employer_name, employer_contact_phone_number, annual_income, number_of_residents, number_of_cats, number_of_dogs, application_approval_status) VALUES (2, 6, 'Clark', 'Kent', '774-447-7474', 'notsuperman@test.com', 'Martha Kent', '447-774-4747', 'June 1938', 'April 11, 2019', 1, 'Daily Planet', '993-399-9393', '30000', 1, 1, 0, 1);

INSERT INTO tenant_application (application_id, unit_id, first_name, last_name, phone_number, email_address, last_residence_owner, last_residence_contact_phone_number, last_residence_tenancy_start_date, last_residence_tenancy_end_date, employment_status, employer_name, employer_contact_phone_number, annual_income, number_of_residents, number_of_cats, number_of_dogs) VALUES (3, 5, 'Diana', 'Prince', '113-331-1313', 'notwonderwoman@test.com', 'Zeus', '555-525-2525', 'January 1942', 'April 12, 2019', 1, 'Self-Employed', 'NA', '60000', 1, 1, 1);


SET IDENTITY_INSERT tenant_application OFF;

SET IDENTITY_INSERT payment ON;

INSERT INTO payment (payment_id, unit_id, tenant_id, payment_amount) VALUES (1, 1, 1, 700.00 );

INSERT INTO payment (payment_id, unit_id, tenant_id, payment_amount) VALUES (2, 1, 1, 700.00 );

INSERT INTO payment (payment_id, unit_id, tenant_id, payment_amount) VALUES (3, 1, 1, 700.00 );

INSERT INTO payment (payment_id, unit_id, tenant_id, payment_amount) VALUES (4, 2, 2, 700.00 );

INSERT INTO payment (payment_id, unit_id, tenant_id, payment_amount) VALUES (5, 2, 2, 700.00 );

INSERT INTO payment (payment_id, unit_id, tenant_id, payment_amount) VALUES (6, 2, 2, 700.00 );

SET IDENTITY_INSERT payment OFF;

ALTER TABLE unit
ADD FOREIGN KEY (property_id)
REFERENCES property(property_id)

ALTER TABLE unit
ADD FOREIGN KEY (tenant_id)
REFERENCES site_user(user_id)

ALTER TABLE service_request
ADD FOREIGN KEY (tenant_id)
REFERENCES site_user(user_id)

ALTER TABLE tenant_application
ADD FOREIGN KEY (unit_id)
REFERENCES unit(unit_id)

ALTER TABLE payment
ADD FOREIGN KEY (unit_id)
REFERENCES unit(unit_id)

COMMIT TRANSACTION;
