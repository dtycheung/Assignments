import numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split
import numpy as np
import pydot
from io import StringIO
from sklearn.tree import export_graphviz


def data_prep():
    # read the dataset
    df = pd.read_csv('D3.csv')
    
    df.drop(['Location', 'MinTemp', 'Humidity3pm', 'Humidity9am', 
          'Temp3pm', 'Temp9am', 'Cloud9am', 'Cloud3pm', 
          'WindGustSpeed', 'WindSpeed9am', 'Pressure9am', 
          'WindDir9am', 'WindDir3pm', 
          'WindGustDir'], axis=1, inplace=True)
    #df = pd.get_dummies(df, columns = [])  # One hot encoding non-ordinal categorical data
    
    # target/input split
    y = df['RainTomorrow']
    X = df.drop(['RainTomorrow'], axis=1)

    # setting random state
    rs = 42

    X_mat = X.to_numpy()
    X_train, X_test, y_train, y_test = train_test_split(X_mat, y, test_size=0.3, stratify=y, random_state=rs)

    return df,X,y,X_train, X_test, y_train, y_test

def analyse_feature_importance(dm_model, feature_names, n_to_display=20):
    # grab feature importances from the model
    importances = dm_model.feature_importances_
    
    # sort them out in descending order
    indices = np.argsort(importances)
    indices = np.flip(indices, axis=0)

    # limit to 20 features, you can leave this out to print out everything
    indices = indices[:n_to_display]

    for i in indices:
        print(feature_names[i], ':', importances[i])

def visualize_decision_tree(dm_model, feature_names, save_name):
    dotfile = StringIO()
    export_graphviz(dm_model, out_file=dotfile, feature_names=feature_names)
    graph = pydot.graph_from_dot_data(dotfile.getvalue())
    graph[0].write_png(save_name) # saved in the following file
