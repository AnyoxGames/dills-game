13
4093103833089
404970775650495 1761863314260363400
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -2.6662659645080566,
    "Y": -11.1165933609008789
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404968201574197:1761863313660601300",
  "next_sibling": "404973280063160:1761863314843894100",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404970775920621:1761863314260425400",
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
  "aoid": "404970776141836:1761863314260477400",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404970775920621:1761863314260425400",
    "DefaultRenderer": "404970776237898:1761863314260499300",
    "DepletedRenderer": "404970776216914:1761863314260494400"
  }
},
{
  "cid": 5,
  "aoid": "404970776165443:1761863314260482400",
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
