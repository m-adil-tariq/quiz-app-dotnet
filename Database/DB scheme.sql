
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