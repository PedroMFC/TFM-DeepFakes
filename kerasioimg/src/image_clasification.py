import tensorflow as tf
import tensorflow_hub as hub 
import numpy as np
from skimage import io, transform
from tensorflow.keras.preprocessing import image

from tensorflow.keras.applications import inception_v3 as inc_net
from lime import lime_image
from skimage.segmentation import mark_boundaries
import matplotlib.pyplot as plt
import download
import hash


def read_and_transform_img(url, height, width):

    img = io.imread(url)
    img = transform.resize(img, (height, width))
    
    img = image.img_to_array(img)
    img = np.expand_dims(img, axis=0)

    return img

def detect(url, model, size, useLime):
    m = tf.keras.Sequential([
        hub.KerasLayer(model)
    ])
    m.build([None, size, size, 3])  # Batch input shape.

    image = read_and_transform_img(url, size, size)
    predictions = m.predict(image)
    print(predictions)
    prediction = np.argmax(predictions)
    print(prediction)

    result = 'fake' if prediction == 1 else 'real'
    fileHash = ""

    # LIME
    if useLime > 0:
        explainer = lime_image.LimeImageExplainer()


        explanation = explainer.explain_instance(image[0].astype('double'), m.predict,top_labels=2, hide_color=0, num_samples=100)


        temp_1, mask_1 = explanation.get_image_and_mask(explanation.top_labels[0], positive_only=True, num_features=5, hide_rest=True)
        temp_2, mask_2 = explanation.get_image_and_mask(explanation.top_labels[0], positive_only=False, num_features=10, hide_rest=False)

        fig, (ax1, ax2) = plt.subplots(1, 2, figsize=(15,15))
        ax1.imshow(mark_boundaries(temp_1, mask_1))
        ax2.imshow(mark_boundaries(temp_2, mask_2))
        ax1.axis('off')
        ax2.axis('off')

        plt.savefig('/home/kerasio/mask_default.png')

        # Guardar en Cloud Storage
        bucket_name = 'imgs-mask'
        name = '/home/kerasio/mask_default.png'
        fileHash = hash.getHash(name)
        download.upload_blob(bucket_name, name, fileHash)

    return result, fileHash