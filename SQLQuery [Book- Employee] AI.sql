INSERT INTO [FoodDeliveryAppBase].[dbo].[TaskTable_Details]
([employeeName], [employeeDesignation], [employeeAddress], [employeeSalary], [employeeLocation])

VALUES
('Ahila', 'Software Engineer', '123, ABC Street, Coimbatore', 50000, 'Chennai'),
('Gokhul', 'Web Developer', '456, XYZ Street, Coimbatore', 52000, 'Madurai'),
('Hari Karan', 'System Analyst', '789, PQR Street, Coimbatore', 55000, 'Trichy'),
('Karthick', 'Database Administrator', '101, MNO Street, Coimbatore', 54000, 'Salem'),
('Kishore', 'Network Engineer', '202, DEF Street, Coimbatore', 53000, 'Erode'),
('Monisha', 'UI/UX Designer', '303, GHI Street, Coimbatore', 51000, 'Tirunelveli'),
('Nethrashree', 'Cyber Security Analyst', '404, JKL Street, Coimbatore', 56000, 'Vellore'),
('Sandhiya', 'Software Tester', '505, STU Street, Coimbatore', 49000, 'Thanjavur'),
('Sarumathi', 'Cloud Solutions Architect', '606, VWX Street, Coimbatore', 58000, 'Kanyakumari'),
('Vetri', 'DevOps Engineer', '707, YZA Street, Coimbatore', 57000, 'Ooty');

truncate table TaskTable_Details;

INSERT INTO [FoodDeliveryAppBase].[dbo].[Book_Details] 
(bookTitle, bookAuthor, bookDescription, bookLanguage, bookGenre, bookPrice, bookPublisher)
VALUES
('The Great Gatsby', 'F. Scott Fitzgerald', 'The story primarily concerns the young and mysterious millionaire Jay Gatsby and his quixotic passion and obsession with the beautiful former debutante Daisy Buchanan.', 'English', 'Classic', 10.99, 'Scribner'),
('To Kill a Mockingbird', 'Harper Lee', 'The story takes place during three years of the Great Depression in the fictional "tired old town" of Maycomb, Alabama.', 'English', 'Classic', 12.99, 'HarperCollins'),
('1984', 'George Orwell', 'It portrays a totalitarian dystopian world where freedom of thought is suppressed.', 'English', 'Dystopian', 9.99, 'Secker & Warburg'),
('Pride and Prejudice', 'Jane Austen', 'The novel follows the character development of Elizabeth Bennet, the dynamic protagonist of the book who learns about the repercussions of hasty judgments and comes to appreciate the difference between superficial goodness and actual goodness.', 'English', 'Romance', 11.99, 'T. Egerton, Whitehall'),
('The Catcher in the Rye', 'J.D. Salinger', 'The novel details two days in the life of 16-year-old Holden Caulfield after he has been expelled from prep school.', 'English', 'Coming-of-Age', 10.49, 'Little, Brown and Company'),
('Moby-Dick', 'Herman Melville', 'The narrators reflections, the overarching description of whaling, and the numerous digressions on topics such as whale biology and whale oil.', 'English', 'Adventure', 13.49, 'Harper & Brothers'),
('The Lord of the Rings', 'J.R.R. Tolkien', 'The story begins in the Shire, where the hobbit Frodo Baggins inherits the Ring from Bilbo Baggins.', 'English', 'Fantasy', 15.99, 'George Allen & Unwin'),
('Brave New World', 'Aldous Huxley', 'The novel anticipates developments in reproductive technology, sleep-learning, psychological manipulation, and classical conditioning.', 'English', 'Dystopian', 10.99, 'Chatto & Windus'),
('War and Peace', 'Leo Tolstoy', 'It is regarded as one of Tolstoy&apos;s finest literary achievements.', 'English', 'Historical Fiction', 14.99, 'The Russian Messenger'),
('The Odyssey', 'Homer', 'The story focuses on the Greek hero Odysseus and his journey home after the fall of Troy.', 'English', 'Epic', 12.49, 'Various')


truncate table Book_Details;