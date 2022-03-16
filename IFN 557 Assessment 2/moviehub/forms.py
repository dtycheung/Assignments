from flask_wtf import FlaskForm
from wtforms.fields import SubmitField, StringField
from wtforms.validators import InputRequired, email

# form used in basket
class CheckoutForm(FlaskForm):
    firstname = StringField("First name", validators=[InputRequired()])
    surname = StringField("Surname", validators=[InputRequired()])
    email = StringField("Email", validators=[InputRequired(), email()])
    phone = StringField("Phone Number", validators=[InputRequired()])
    cardnumber = StringField("Credit Card Detail", validators=[InputRequired()])
    expirydate = StringField("Vaild Date", validators=[InputRequired()])
    csc = StringField("Secuity Number", validators=[InputRequired()])
    submit = SubmitField("Submit")
