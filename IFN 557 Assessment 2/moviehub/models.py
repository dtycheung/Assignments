from . import db


class Category(db.Model):
    __tablename__='categories'
    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String(64), unique=True)
    gen_image = db.Column(db.String(60), nullable=False)
    movies = db.relationship('Movie', backref='Category', cascade="all, delete-orphan")

    def __repr__(self):
        str = "Id: {}, Name: {}, Gen_image: {}\n" 
        str =str.format( self.id, self.name, self.gen_image)
        return str

orderdetails = db.Table('orderdetails', 
    db.Column('order_id', db.Integer,db.ForeignKey('orders.id'), nullable=False),
    db.Column('movie_id',db.Integer,db.ForeignKey('movies.id'),nullable=False),
    db.PrimaryKeyConstraint('order_id', 'movie_id'))

class Movie(db.Model):
    __tablename__='movies'
    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String(64),nullable=False)
    director = db.Column(db.String(64), nullable=False)
    stars = db.Column(db.String(64), nullable=False)
    mov_image = db.Column(db.String(60), nullable=False)
    banner = db.Column(db.String(64))
    price = db.Column(db.Float, nullable=False)
    trailer = db.Column(db.String(256))
    new = db.Column(db.String(3))
    cate_id = db.Column(db.Integer, db.ForeignKey('categories.id'))
    article = db.relationship('Article', backref='Movie', cascade="all, delete-orphan")

    def __repr__(self):
        str = "Id: {}, Name: {}, Director: {}, Star: {}, Mov_Image: {}, Banner: {}, Price: {}, Category: {}, Trailer: {}, New: {}\n" 
        str =str.format( self.id, self.name, self.director, self.stars, self.mov_image, self.banner, self.price, self.cate_id, self.trailer, self.new)
        return str

class Article(db.Model):
    __tablename__='articles'
    id = db.Column(db.Integer, primary_key=True)
    movie_id = db.Column(db.Integer, db.ForeignKey('movies.id'))
    artType = db.Column(db.String(64), nullable=False)
    content = db.Column(db.Text, nullable=False)


    def __repr__(self):
        str = "Id: {}, Movie_id: {}, ArtType: {}, Content: {}\n"
        str = str.format(self.id, self.movie_id, self.artType, self.content)
        return str


class Order(db.Model):
    __tablename__='orders'
    id = db.Column(db.Integer, primary_key=True)
    status = db.Column(db.Boolean, default=False)
    firstname = db.Column(db.String(64))
    surname = db.Column(db.String(64))
    email = db.Column(db.String(128))
    phone = db.Column(db.String(32))
    totalcost = db.Column(db.Float)
    date = db.Column(db.DateTime)
    cardNumber = db.Column(db.Integer)
    expiryDate = db.Column(db.Integer)
    csc = db.Column(db.Integer)
    movies = db.relationship("Movie", secondary=orderdetails, backref="orders")
    
    def __repr__(self):
        str = "id: {}, Status: {}, Firstname: {}, Sname: {}, Email: {}, Phone: {}, Date: {}, Movie: {}, Total Cost: {}, Card Number: {}, Expired Date: {}, CSC: {}\n" 
        str =str.format( self.id, self.status,self.firstname,self.surname, self.email, self.phone, self.date, self.movies, self.totalcost, self.cardNumber, self.expiryDate, self.csc)
        return str
