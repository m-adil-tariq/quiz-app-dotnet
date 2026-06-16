
-- admin_auth
CREATE TABLE admin_auth (
    ad_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ad_user NVARCHAR(20) NOT NULL,
    ad_password NVARCHAR(20) NOT NULL
);

-- student
CREATE TABLE student (
    std_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    std_name NVARCHAR(20) NOT NULL,
    std_batchcode NVARCHAR(20) NOT NULL,
    std_password NVARCHAR(20) NOT NULL,
    std_ad_id INT NULL,
    FOREIGN KEY (std_ad_id) REFERENCES admin_auth(ad_id)
);

-- exam
CREATE TABLE exam (
    ex_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ex_name NVARCHAR(20) NOT NULL UNIQUE
);

-- question
CREATE TABLE question (
    q_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    q_title NVARCHAR(MAX) NOT NULL,
    q_a NVARCHAR(200) NOT NULL,
    q_b NVARCHAR(200) NOT NULL,
    q_c NVARCHAR(200) NOT NULL,
    q_d NVARCHAR(200) NOT NULL,
    q_correct NVARCHAR(200) NOT NULL,
    q_addeddate NVARCHAR(20) NOT NULL,
    q_fk_ad INT NULL,
    q_fk_ex INT NULL,
    FOREIGN KEY (q_fk_ad) REFERENCES admin_auth(ad_id),
    FOREIGN KEY (q_fk_ex) REFERENCES exam(ex_id)
);

-- set_exam
CREATE TABLE set_exam (
    set_exam_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    set_exam_date VARCHAR(20) NOT NULL,
    std_id_fk INT NULL,
    ex_id_fk INT NULL,
    CONSTRAINT uq_student_exam UNIQUE (std_id_fk, ex_id_fk),
    FOREIGN KEY (ex_id_fk) REFERENCES exam(ex_id),
    FOREIGN KEY (std_id_fk) REFERENCES student(std_id)
);

-- score
CREATE TABLE score (
    score_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    score INT NOT NULL,
    percentage FLOAT NOT NULL,
    fk_set_ex_id INT NULL UNIQUE,
    FOREIGN KEY (fk_set_ex_id) REFERENCES set_exam(set_exam_id)
);

CREATE PROC [dbo].[assign_exam]
(
    @set_exam_date VARCHAR(20),
    @std_id_fk INT,
    @ex_id_fk INT,
    @set_exam_id INT OUTPUT
)
AS
BEGIN
    INSERT INTO set_exam (set_exam_date, std_id_fk, ex_id_fk)
    VALUES (@set_exam_date, @std_id_fk, @ex_id_fk);

    -- Return the newly inserted ID
    SET @set_exam_id = SCOPE_IDENTITY();
END;


create proc insert_admin
				@ad_user nvarchar(20),
				@ad_password nvarchar(20),
				@ad_id int output
as
begin

insert into admin_auth(ad_user, ad_password) values (@ad_user, @ad_password);
set @ad_id = SCOPE_IDENTITY();
end

CREATE PROCEDURE insert_exam
    @ex_name NVARCHAR(20),
    @ex_id INT OUTPUT
AS
BEGIN
    INSERT INTO exam (ex_name)
    VALUES (@ex_name);

    SET @ex_id = SCOPE_IDENTITY();
END

CREATE PROC [dbo].[insert_question]
(
    @q_title NVARCHAR(MAX),
    @q_a NVARCHAR(200),
    @q_b NVARCHAR(200),
    @q_c NVARCHAR(200),
    @q_d NVARCHAR(200),
    @q_correct NVARCHAR(200),
    @q_addeddate NVARCHAR(20),
    @q_fk_ad INT,
    @q_fk_ex INT,
    @q_id INT OUTPUT -- Added OUTPUT parameter
)
AS
BEGIN
    INSERT INTO question(q_title, q_a, q_b, q_c, q_d, q_correct, q_addeddate, q_fk_ad, q_fk_ex)
    VALUES (@q_title, @q_a, @q_b, @q_c, @q_d, @q_correct, @q_addeddate, @q_fk_ad, @q_fk_ex);

    -- Return the generated q_id
    SET @q_id = SCOPE_IDENTITY();
END;


create proc [dbo].[insert_score](@score int, @percentage float, @fk_set_ex_id int, @score_id int output)
as
begin 
	insert into score
	values(@score, @percentage, @fk_set_ex_id)
	SET @score_id = SCOPE_IDENTITY();
end

create proc insert_student(@std_name nvarchar(20),@std_batchcode nvarchar(20), @std_password nvarchar(20), @std_ad_id int, @std_id int output)
as
begin
	insert into student
	values(@std_name ,@std_batchcode, @std_password, @std_ad_id);
	set @std_id = SCOPE_IDENTITY();
end;

-- 1. Insert Admins
INSERT INTO admin_auth (ad_user, ad_password) VALUES
('admin', 'admin123');

-- 2. Insert Students (referencing admin IDs 1 and 2)
INSERT INTO student (std_name, std_batchcode, std_password, std_ad_id) VALUES
('Alice Khan',    'BSCS-F21', 'alice123', 1),
('Bob Ahmed',     'BSCS-F21', 'bob123',   1),
('Sara Malik',    'BSCS-F22', 'sara123',  2),
('Usman Tariq',   'BSCS-F22', 'usman123', 2);

-- 3. Insert Exams
INSERT INTO exam (ex_name) VALUES
('OOP Midterm'),
('DSA Final'),
('Networks Quiz');

-- 4. Insert Questions (admin 1, various exams)
INSERT INTO question (q_title, q_a, q_b, q_c, q_d, q_correct, q_addeddate, q_fk_ad, q_fk_ex) VALUES
('What does OOP stand for?',              'Object Oriented Programming', 'Open Object Processing', 'Ordered Object Protocol', 'None',                         'Object Oriented Programming', '2024-01-10', 1, 1),
('Which keyword is used for inheritance?','extends',                     'inherits',               'implements',              'derived',                      'extends',                     '2024-01-10', 1, 1),
('What is a constructor?',                'A destructor method',         'A method to init objects','A loop structure',       'A conditional statement',      'A method to init objects',    '2024-01-11', 1, 1),
('What is a stack?',                      'FIFO structure',              'LIFO structure',          'Linked list',            'Binary tree',                  'LIFO structure',              '2024-02-01', 1, 2),
('Time complexity of binary search?',     'O(n)',                        'O(n^2)',                  'O(log n)',               'O(1)',                         'O(log n)',                    '2024-02-01', 1, 2),
('What does OSPF stand for?',             'Open Short Path First',       'Open Shortest Path First','Optimized Shortest Path','Open System Path First',      'Open Shortest Path First',    '2024-03-01', 2, 3),
('What is a subnet mask used for?',       'Encryption',                  'Routing',                 'Dividing IP into network/host','Assigning MAC address', 'Dividing IP into network/host','2024-03-01', 2, 3);

-- 5. Assign Exams to Students
INSERT INTO set_exam (set_exam_date, std_id_fk, ex_id_fk) VALUES
('2024-01-15', 1, 1),  -- Alice  → OOP Midterm
('2024-01-15', 2, 1),  -- Bob    → OOP Midterm
('2024-02-10', 1, 2),  -- Alice  → DSA Final
('2024-02-10', 3, 2),  -- Sara   → DSA Final
('2024-03-05', 4, 3);  -- Usman  → Networks Quiz

-- 6. Insert Scores (referencing set_exam IDs 1-5)
INSERT INTO score (score, percentage, fk_set_ex_id) VALUES
(3, 100.0, 1),  -- Alice  → OOP:      3/3 = 100%
(2, 66.7,  2),  -- Bob    → OOP:      2/3 = 66.7%
(1, 50.0,  3),  -- Alice  → DSA:      1/2 = 50%
(2, 100.0, 4),  -- Sara   → DSA:      2/2 = 100%
(1, 50.0,  5);  -- Usman  → Networks: 1/2 = 50%