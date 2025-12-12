13
3491808411649
404879789751561 1761863293060554800
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -16.7765693664550781,
    "Y": 3.1219811439514160
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404877285442014:1761863292477047900",
  "next_sibling": "404883437806588:1761863293910555700",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404879790107902:1761863293060636900",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404879790272162:1761863293060675300",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404879790107902:1761863293060636900",
    "DefaultRenderer": "404879790370030:1761863293060697900",
    "DepletedRenderer": "404879790341865:1761863293060691600"
  }
},
{
  "cid": 5,
  "aoid": "404879790297661:1761863293060681100",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
