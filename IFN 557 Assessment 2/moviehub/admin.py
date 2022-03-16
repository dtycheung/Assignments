from flask import Blueprint
from . import db
from .models import Category, Movie, Article, Order

bp = Blueprint('admin', __name__, url_prefix='/admin/')

@bp.route('/dbseed/')
def dbseed():
    category1 = Category(name= 'Horror', gen_image= 'rm.png')
    category2 = Category(name= 'Comedy', gen_image= '3i.png')
    category3 = Category(name= 'Romance', gen_image= 'lala.png')
    category4 = Category(name= 'Action', gen_image= 'suicide2.png')

    try:
        db.session.add(category1)
        db.session.add(category2)
        db.session.add(category3)
        db.session.add(category4)
        db.session.commit()
    except:
        return 'There was an issue adding the genres in dbseed function'
    
    movie1 = Movie(name = 'Rigor Mortis 殭屍',\
        director = 'Juno Mak',\
        stars = 'Chin Siu-Ho, Wai Ying Hung, Paw Hee Ching, Chan Yau',\
        mov_image = 'rm_cover.gif',\
        banner = 'rmbanner.jpg',\
        price = 19.52,\
        trailer = '7LqZoI0SAb4',\
        new = 'old',\
        cate_id = 1)
    movie2 = Movie(name = '3 Idiots',\
        director = 'Rajkumar Hirani',\
        stars = 'Aamir Khan, R. Madhavan, Sharman Joshi',\
        mov_image = '3icd.jpg',\
        banner = '3ibanner.jpg',\
        price = 42.66,\
        trailer = 'K0eDlFX9GMc',\
        new = 'old',\
        cate_id = 2)
    movie3 = Movie(name = 'Avengers 4 End Game',\
        director = 'Anthony Russo, Joe Russo',\
        stars = 'Chris Hemsworth, Robert Downey Jr, Chris Evans, Mark Ruffalo, Scarlett Johansson',\
        mov_image = 'avcol.jpg',\
        banner = 'avbanner.jpg',\
        price = 19.97,\
        trailer = 'TcMBFSGVi1c',\
        new = 'new',\
        cate_id = 4)
    movie4 = Movie(name = 'La La Land',\
        director = 'Damien Chazelle',\
        stars = 'Ryan Gosling, Emma Stone, John Legend',\
        mov_image = 'lala.jpg',\
        banner = 'lalabanner.jpg',\
        price = 10.00,\
        trailer = '0pdqf4P9MB8',\
        new = 'new',\
        cate_id = 3)
    movie5 = Movie(name = 'Kung Fu Hustle 功夫',\
        director = 'Stephen Chow',\
        stars = 'Stephen Chow, ShengYi Huang, Yuen Qiu, Yuen Wah',\
        mov_image = 'kfh.jpg',\
        banner = 'kfhbanner,jpg' ,\
        price = 19.99,\
        trailer = 'PRbPXbgsKyE',\
        new = 'old',\
        cate_id = 2)
    movie6 = Movie(name = 'Ju-On',\
        director = 'Takashi Shimizu',\
        stars = 'Megumi Okina, Misaki Itô, Misa Uehara, Yui Ichikawa, Kanji Tsuda',\
        mov_image = 'juon.jpg',\
        banner = 'junobanner.jpg',\
        price = 13.05,\
        trailer = 'EYyPTyXlT9w',\
        new = 'old',\
        cate_id = 1)
    movie7 = Movie(name = 'Ringu',\
        director = 'Hideo Nakata',\
        stars = 'Nanako Matsushima, Miki Nakatani, Yûko Takeuchi',\
        mov_image = 'ring.jpg',\
        banner = 'ringu.jpg',\
        price = 27.39,\
        trailer = 'WcgCM2FyU8s',\
        new = 'old',\
        cate_id = 1)
    movie8 = Movie(name = 'Suicide Squad',\
        director = 'David Ayer',\
        stars = 'Will Smith, Jared Leto, Margot Robbie, Joel Kinnaman, Viola Davis',\
        mov_image = 'sq.jpg',\
        banner = 'sqbanner.jpg',\
        price = 9.24,\
        trailer = 'CmRih_VtVAs',\
        new = 'old',\
        cate_id = 4)
    movie9 = Movie(name = 'Mission: Impossible - Fallout',\
        director = 'Christopher McQuarrie',\
        stars = 'Tom Cruise, Rebecca Ferguson, Vanessa Kirby, Henry Cavill, Michelle Monaghan',\
        mov_image = 'mi6.jpg',\
        banner = 'mi6banner.jpg',\
        price = 9.51,\
        trailer = 'wb49-oV0F78',\
        new = 'new',\
        cate_id = 4)
    movie10 = Movie(name = 'Your Name 君の名は',\
        director = 'Makoto Shinkai',\
        stars = 'Ryunosuke Kamiki, Mone Kamishiraishi',\
        mov_image = 'name.jpg',\
        banner = 'ynbanner.jpg',\
        price = 25.32,\
        trailer = 'xU47nhruN-Q',\
        new = 'new',\
        cate_id = 3)
    movie11 = Movie(name = 'A Star is Born',\
        director = 'Bradley Cooper',\
        stars = 'Bradley Cooper, Lady Gaga',\
        mov_image = 'gaga.jpg',\
        banner = 'gagabanner.jpg',\
        price = 9.32,\
        trailer = 'nSbzyEJ8X9E',\
        new = 'new',\
        cate_id = 3)
    movie12 = Movie(name = 'Inglourious Basterds',\
        director = 'Quentin Tarantino',\
        stars = 'Brad Pitt, Melanie Laurent, Christoph Waltz, Eli Roth, Michael Fassbender',\
        mov_image = 'ib.jpg',\
        banner = 'ibbanner.jpg',\
        price = 26.66,\
        trailer = 'nSbzyEJ8X9E',\
        new = 'old',\
        cate_id = 2)
    movie13 = Movie(name = 'Wild Tales',\
        director = 'Damián Szifron',\
        stars = 'Darío Grandinetti,  María Marull, Mónica Villa',\
        mov_image = 'wt.jpg',\
        banner = 'wtbanner.jpg',\
        price = 17.74 ,\
        trailer = 'Utq0aDEp084',\
        new = 'new',\
        cate_id = 2)

    try:
        db.session.add(movie1)
        db.session.add(movie2)
        db.session.add(movie3)
        db.session.add(movie4)
        db.session.add(movie5)
        db.session.add(movie6)
        db.session.add(movie7)
        db.session.add(movie8)
        db.session.add(movie9)
        db.session.add(movie10)
        db.session.add(movie11)
        db.session.add(movie12)
        db.session.add(movie13)
        db.session.commit()

    except:
        return 'There was an issue adding the movie in dbseed function'

    article1 = Article(movie_id = 1,\
        artType = 'Storyline',\
        content = 'In this eerie and chilling, contemporary, action/special effects laden homage to the classic Chinese vampire movies of the 1980, writer-director-producer, Juno Mak makes his feature directorial debut. Co-produced by J-Horror icon Takashi Shimizu, and reuniting some of the original cast members of the classic Mr. Vampire series, RIGOR MORTIS is set in a creepy and moody Hong Kong public housing tower whose occupants we soon discover, run the gamut from the living to the dead, to the undead, along with ghosts, vampires and zombies.')
    article2 = Article(movie_id = 1,\
        artType = 'Review',\
        content = 'This is a tale of a man and the inhabitants of the building he moves to. Asian ghost stories are one of my favorite genres and this film delivers in high quality. At times it leaves you wondering whats real and what isnt. Ive watched this several times and it still delivers.'
        )
    article3 = Article(movie_id = 2,\
        artType = 'Storyline',\
        content = 'Farhan Qureshi and Raju Rastogi want to re-unite with their fellow collegian, Rancho, after faking a stroke aboard an Air India plane, and excusing himself from his wife - trouser less - respectively. Enroute, they encounter another student, Chatur Ramalingam, now a successful businessman, who reminds them of a bet they had undertaken 10 years ago. The trio, while recollecting hilarious antics, including their run-ins with the Dean of Delhis Imperial College of Engineering, Viru Sahastrabudhe, race to locate Rancho, at his last known address - little knowing the secret that was kept from them all this time') 
    article4 = Article(movie_id = 3,\
        artType = 'Storyline',\
        content = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins due to the efforts of the Mad Titan, Thanos. With the help of remaining allies, the Avengers must assemble once more in order to undo Thanos's actions and undo the chaos to the universe, no matter what consequences may be in store, and no matter who they face...") 
    article5 = Article(movie_id = 4,\
        artType = 'Storyline',\
        content = "Aspiring actress serves lattes to movie stars in between auditions and jazz musician Sebastian scrapes by playing cocktail-party gigs in dingy bars. But as success mounts, they are faced with decisions that fray the fragile fabric of their love affair, and the dreams they worked so hard to maintain in each other threaten to rip them apart."
        )
    article6 = Article(movie_id = 5,\
        artType = 'Storyline',\
        content = "Set in Canton, China in the 1940s, the story revolves in a town ruled by the Axe Gang, Sing who desperately wants to become a member. He stumbles into a slum ruled by eccentric landlords who turns out to be the greatest kung-fu masters in disguise. Sing's actions eventually cause the Axe Gang and the slumlords to engage in an explosive kung-fu battle. Only one side will win and only one hero will emerge as the greatest kung-fu master of all."
        )
    article7 = Article(movie_id = 6,\
        artType = 'Storyline',\
        content = "In Japan, when the volunteer social assistant Rika Nishina is assigned to visit a family, she is cursed and chased by two revengeful fiends: Kayako, a woman brutally murdered by her husband and her son Toshio. Each person that lives in or visits the haunted house is murdered or disappears."
        )
    article8 = Article(movie_id = 7,\
        artType = 'Storyline',\
        content = "Reiko Asakawa is researching into a 'Cursed Video' interviewing teenagers about it. When her niece Tomoko dies of 'sudden heart failure' with an unnaturally horrified expression on her face, Reiko investigates. She finds out that some of Tomoko's friends, who had been on a holiday with Tomoko the week before, had died on exactly the same night at the exact same time in the exact same way. Reiko goes to the cabin where the teens had stayed and finds an 'unlabeled' video tape. Reiko watched the tape to discover to her horror it is in fact the 'cursed videotape'. Ex-Husband Ryuji helps Reiko solve the mystery, Reiko makes him a copy for further investigation. Things become more tense when their son Yoichi watches the tape saying Tomoko had told him to. Their discovery takes them to a volcanic island where they discover that the video has a connection to a psychic who died 30 years ago, and her child Sadako..."
        )
    article9 = Article(movie_id = 8,\
        artType = 'Storyline',\
        content = "It feels good to be bad...Assemble a team of the world's most dangerous, incarcerated Super Villains, provide them with the most powerful arsenal at the government's disposal, and send them off on a mission to defeat an enigmatic, insuperable entity. U.S. intelligence officer Amanda Waller has determined only a secretly convened group of disparate, despicable individuals with next to nothing to lose will do. However, once they realize they weren't picked to succeed but chosen for their patent culpability when they inevitably fail, will the Suicide Squad resolve to die trying, or decide it's every man for himself?"
        )
    article10 = Article(movie_id = 9,\
        artType = 'Storyline',\
        content = "Two years after Ethan Hunt had successfully captured Solomon Lane, the remnants of the Syndicate have reformed into another organization called the Apostles. Under the leadership of a mysterious fundamentalist known only as John Lark, the organization is planning on acquiring three plutonium cores. Ethan and his team are sent to Berlin to intercept them, but the mission fails when Ethan saves Luther and the Apostles escape with the plutonium. With CIA agent August Walker joining the team, Ethan and his allies must now find the plutonium cores before it's too late."
        )
    article11 = Article(movie_id = 10,\
        artType = 'Storyline',\
        content = "Mitsuha is the daughter of the mayor of a small mountain town. She's a straightforward high school girl who lives with her sister and her grandmother and has no qualms about letting it be known that she's uninterested in Shinto rituals or helping her father's electoral campaign. Instead she dreams of leaving the boring town and trying her luck in Tokyo. Taki is a high school boy in Tokyo who works part-time in an Italian restaurant and aspires to become an architect or an artist. Every night he has a strange dream where he becomes...a high school girl in a small mountain town."
        )
    article12 = Article(movie_id = 11,\
        artType = 'Storyline',\
        content = "Seasoned musician Jackson Maine (Bradley Cooper) discovers-and falls in love with-struggling artist Ally (Gaga). She has just about given up on her dream to make it big as a singer - until Jack coaxes her into the spotlight. But even as Ally's career takes off, the personal side of their relationship is breaking down, as Jack fights an ongoing battle with his own internal demons."
        )
    article13 = Article(movie_id = 12,\
        artType = 'Storyline',\
        content = "In German-occupied France, young Jewish refugee Shosanna Dreyfus witnesses the slaughter of her family by Colonel Hans Landa. Narrowly escaping with her life, she plots her revenge several years later when German war hero Fredrick Zoller takes a rapid interest in her and arranges an illustrious movie premiere at the theater she now runs. With the promise of every major Nazi officer in attendance, the event catches the attention of the 'Basterds', a group of Jewish-American guerrilla soldiers led by the ruthless Lt. Aldo Raine. As the relentless executioners advance and the conspiring young girl's plans are set in motion, their paths will cross for a fateful evening that will shake the very annals of history.")
    article14 = Article(movie_id = 13,\
        artType = 'Storyline',\
        content = 'The film is divided into six segments. (1) "Pasternak": While being on a plane, a model and a music critic realise they have a common acquaintance called Pasternak. Soon they discover that every passenger and crew member on board know Pasternak. Is this coincidence? (2) "The Rats": A waitress recognizes her client - its the loan shark who caused a tragedy in her family. The cook suggests mixing rat poison with his food, but the waitress refuses. The stubborn cook, however, decides to proceed with her plan. (3) "The Strongest": Two drivers on a lone highway have an argument with tragic consequences. (4) "Little Bomb": A demolition engineer has his car towed by a truck for parking in a wrong place and he has an argument with the employee of the towing company. This event destroys his private and professional life, and he plots revenge against the corrupt towing company and the city hall. (5) The Proposal: A reckless son of a wealthy family has an overnight hit-and-run accident, in which a pregnant woman gets killed. He wakes his parents up and his father calls the lawyer. The parents propose to pay the groundkeeper to take the blame for the boy. Soon the father discovers that he is a victim of extortion of his lawyer and the public prosecutor in charge of the investigation. What will be his decision? (6) "Until Death Do Us Apart": During the wedding party, the bride discovers that her newlywed husband has been cheating on her with one of the guests, and she decides to pay him back.'
        )
    article15 = Article(movie_id = 13,\
        artType = 'Review',\
        content = 'Perhaps the best omnibus dark comedy ever made. This movie is funny, it explores some of the darker parts of humanity but it does so with so much wit and intelligence. It was a great hit in South America, and understandably so. Despite dark and cynical take on the human condition, the movie is lighthearted and highly watchable, and uncompromisingly original.'
        )
     
    try:
        db.session.add(article1)
        db.session.add(article2)
        db.session.add(article3)
        db.session.add(article4)
        db.session.add(article5)
        db.session.add(article6)
        db.session.add(article7)
        db.session.add(article8)
        db.session.add(article9)
        db.session.add(article10)
        db.session.add(article11)
        db.session.add(article12)
        db.session.add(article13)
        db.session.add(article14)
        db.session.add(article15)
        db.session.commit()
    except:
        return 'There was an issue adding the article in dbseed function '

    return 'Good mo'