from flask import Blueprint, render_template, url_for, request, session, flash, redirect
from .models import Category, Movie, Order, Article
from datetime import datetime
from .forms import CheckoutForm
from . import db
#import moviehub


bp = Blueprint('main', __name__)


@bp.route('/')
def index():
    categories = Category.query.order_by(Category.id).all()
    new = Movie.query.filter(Movie.new == "new")
    return render_template('index.html', categories = categories, new = new)

@bp.route('/list/')
def movielist():
    categories = Category.query.order_by(Category.id).all()            
    movies = Movie.query.order_by(Movie.id).all()
    articles = Article.query.filter(Article.movie_id == Movie.id)
    return render_template('list.html', categories = categories, movies = movies, articles = articles)

@bp.route('/list/<int:cateid>/')
def movie(cateid):
    movies = Movie.query.filter(Movie.cate_id  == cateid)
    categories = Category.query.order_by(Category.id).all()
    catefortitle = Category.query.filter(Category.id  == cateid)
    articles = Article.query.filter(Article.movie_id == Movie.id)
    return render_template('list.html', movies = movies, categories = categories, catefortitle = catefortitle, articles = articles)


@bp.route('/movie/<int:movid>/') 
def moviedetail(movid):
    movies = Movie.query.filter(Movie.id == movid)
    articles = Article.query.order_by(Article.movie_id == movid)
    categories = Category.query.order_by(Category.id).all()
    return render_template('movie.html', movies = movies, articles = articles, categories = categories)



@bp.route('/result/')
def search():
    categories = Category.query.order_by(Category.id).all()
    search = request.args.get('search')
    search = '%{}%'.format(search)
    movies = Movie.query.filter(Movie.name.like(search)).all()
    articles = Article.query.filter(Article.movie_id == Movie.id)
    print(search)
    return render_template('list.html', movies = movies, categories= categories, articles = articles)

@bp.route('/order', methods=['POST','GET'])  
def order():
    categories = Category.query.order_by(Category.id).all()
    movie_id = request.values.get('movie_id')
    articles = Article.query.filter(Article.movie_id == Movie.id)

    #moviesinfo = Movie.query.order_by(Movie.id).all()

    # retrieve order if there is one
    if 'order_id'in session.keys():
        order = Order.query.get(session['order_id'])
        # order will be None if order_id stale
    else:
        # there is no order
        order = None

    # create new order if needed
    if order is None:
        order = Order(status = False, firstname='', surname='', email='', phone='', cardNumber='', expiryDate='', csc='', totalcost=0, date=datetime.now())
        try:
            db.session.add(order)
            db.session.commit()
            session['order_id'] = order.id
        except:
            print('failed at creating a new order')
            order = None
    
    # calcultate totalprice
    totalprice = 0
    if order is not None:
        for movie in order.movies:
            totalprice = totalprice + movie.price
    
    # are we adding an item?
    if movie_id is not None and order is not None:
        Moviesss = Movie.query.get(movie_id)
        if Moviesss not in order.movies:
            try:
                order.movies.append(Moviesss)
                db.session.commit()
            except:
                return 'There was an issue adding the item to your basket'
            return redirect(url_for('main.order',  order = order, totalprice = totalprice, categories = categories))
        else:
            flash('item already in basket')
            return redirect(url_for('main.order',  order = order, totalprice = totalprice, categories = categories))
    
    return render_template('order.html', order = order, totalprice = totalprice, categories = categories, articles = articles)


# Delete specific basket items
@bp.route('/deleteorderitem', methods=['POST'])
def deleteorderitem():
    id=request.form['id']
    if 'order_id' in session:
        order = Order.query.get_or_404(session['order_id'])
        tour_to_delete = Movie.query.get(id)
        try:
            order.movies.remove(tour_to_delete)
            db.session.commit()
            return redirect(url_for('main.order'))
        except:
            return 'Problem deleting item from order'
    return redirect(url_for('main.order'))


# Scrap basket
@bp.route('/deleteorder')
def deleteorder():
    if 'order_id' in session:
        del session['order_id']
        flash('All items deleted')
    return redirect(url_for('main.index'))


@bp.route('/checkout/', methods=['POST','GET'])
def checkout():
    form = CheckoutForm() 
    if 'order_id' in session:
        order = Order.query.get_or_404(session['order_id'])
       
        if form.validate_on_submit():
            order.status = True
            order.firstname = form.firstname.data
            order.surname = form.surname.data
            order.email = form.email.data
            order.phone = form.phone.data
            order.cardnumber = form.cardnumber.data
            order.expirydate = form.expirydate.data
            order.csc = form.csc.data
            totalcost = 0
            for Movie in order.movies:
                totalcost = totalcost + Movie.price
            order.totalcost = totalcost
            order.date = datetime.now()
            try:
                db.session.commit()
                del session['order_id']
                flash('Your order has been confirmed, thank you!')
                return redirect(url_for('main.index'))
            except:
                return 'There was an issue completing your order'
    categories = Category.query.order_by(Category.id).all()

    return render_template('checkout.html', form = form, categories = categories)