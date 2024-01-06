## Gereksinimler
- python ● 3.8.10
- Unity ● 2022.3.4f1

## Kurulum
pip ile gerekli kütüphaneler kurulur.
```bash
cd hexapodwithai
pip install virtualenv
virtualenv myenv
./myenv/Scripts/activate
pip install -r requirements.txt
```

Unity paketlerini kurmak için Packages içinden manifest.json dosyası kullanılarak kurulum yapılır.

## Kullanım
1. Unity'de proje açılır.
2. `mlagents-learn --run-id=<id_name> [--resume | --force]` komutu ile eğitim başlatılır.
3. Konsolda port dinleme aktif olduğunda Unity'de play tuşuna basılır.
